//document.addEventListener("onload",getData);
document.addEventListener("load", getData());
//var clonProducts;
function drowProduct(product) {
    temp = document.getElementById("temp-card");
    var clonProducts = temp.content.cloneNode(true);
    clonProducts.querySelector(".productName").innerHTML = product.productName;
    clonProducts.getElementById("img").src = "images/" + product.imageName;
    clonProducts.querySelector(".price").innerHTML = product.price;
    clonProducts.getElementById("btn").addEventListener("click",()=> { addToCart(product); });
    document.getElementById("ProductList").appendChild(clonProducts);
}

function drowCategory(category) {
    temp = document.getElementById("temp-category");
    var clonCategory = temp.content.cloneNode(true);
    clonCategory.querySelector(".OptionName").innerHTML = category.categoryName;
    clonCategory.getElementById("ch").addEventListener("click", function () { ifChecked(this, category.categoryId); });
    document.getElementById("filters").appendChild(clonCategory);
}

var orderList = [];

function countItems() {
    var count = 0;
    if (sessionStorage.getItem('productsList') != null) {
        orderList = JSON.parse(sessionStorage.getItem('productsList'));
        orderList.forEach(ord => {
            count = count + ord.count;
        })
    }
    return count;
}

function addToCart(product) {
    //var count = countItems();
    //count = count + 1;
    //document.getElementById("ItemsCountText").innerHTML = count;
    if (sessionStorage.getItem('olduser') == null) {
        alert("כדי להזמין יש להתחבר ")

    }
    else {
        var ind = orderList.findIndex(x => x.product.productId == product.productId);
        if (ind != -1) {
            orderList[ind].count = orderList[ind].count + 1;
        }
        else {
            orderList.push({ "product": product, "count": 1 });
            alert("המוצר נוסף בהצלחה")
        }
        sessionStorage.setItem('productsList', JSON.stringify(orderList));    
    }
    
}

function ifChecked(c, categoryId) {
    if (c.checked == true) {
        remove();
        getByCategory(categoryId);
    }
    else {
        remove();
        getProducts();
    }

}

function remove() {
    document.getElementById("ProductList").innerHTML = "";
}
function back() {
    remove();
    var div = document.getElementById("ProductList").children;
    for (let i = 0; i < div.length; i++) {
        div[i].style.display = "block";
    }
}


var flag = [JSON.parse(sessionStorage.getItem('numOfCategories'))];
for (var i = 0; i < flag.length; i++) {
    flag[i] = false;
}
var flag = "";
function getByCategory(categoryId) {
    fetch("api/Products/" + categoryId)
        .then((response) => {
            if (response.ok)
                return response.json();
            else throw new Error("not found");
        })
        .then(data => {
            let listOfProducts = JSON.stringify(data);
            listOfProducts = JSON.parse(listOfProducts);
            //document.getElementById("counter").innerHTML = listOfProducts.length;
            for (var i = 0; i < listOfProducts.length; i++) {
                drowProduct(listOfProducts[i]);
            }
        })
        .catch(er => { console.log(er); })
}

function getProducts() {
    fetch("api/Products")
        .then((response) => {
            if (response.ok)
                return response.json();
            else throw new Error("not found");
        })
        .then(data => {
            let listOfProducts = JSON.stringify(data);
            listOfProducts = JSON.parse(listOfProducts);
            //document.getElementById("counter").innerHTML = listOfProducts.length;
            for (var i = 0; i < listOfProducts.length; i++) {
                drowProduct(listOfProducts[i]);
            }
            sessionStorage.setItem('numOfCategories', JSON.stringify(listOfProducts.length));
        })
        .catch(er => { console.log(er); })

}

function getCategories() {
    fetch("api/Category")
        .then((response) => {
            if (response.ok)
                return response.json();
            else throw new Error("not found");
        })
        .then(data => {
            let listOfCategories = JSON.stringify(data);
            listOfCategories = JSON.parse(listOfCategories);
            for (var i = 0; i < listOfCategories.length; i++) {
                drowCategory(listOfCategories[i]);
            }

        })
        .catch(er => { console.log(er); })

}

function getData() {
    getProducts();
    getCategories();
    //document.getElementById("ItemsCountText").innerHTML = countItems();
    
}

