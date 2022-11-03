
var sum = 0;


function loadCart() {
    let orders = JSON.parse(sessionStorage.getItem('productsList'));
    orders.forEach(drawOrder);
    orders.forEach((p) => { sum += p.product.price; })
    document.getElementById("itemCount").innerHTML = orders.length;
    document.getElementById("totalAmount").innerHTML = sum;
}


function drawOrder(product) {
    var url = "images/";
    s = document.getElementById("temp-row");
    let clonS = s.content.cloneNode(true);
    clonS.querySelector(".image").style.backgroundImage = "url(" + url + product.product.imageName + ")";
    clonS.querySelector(".itemName").innerHTML = product.product.description;
    clonS.querySelector(".price").innerHTML = product.product.price + ' ' + 'ש"ח ';
    clonS.querySelector(".expandoHeight").addEventListener("click", () => {
        removeItem(product)

    });

    document.getElementById("tbody").appendChild(clonS);

}



function removeItem(product) {
    let orders = JSON.parse(sessionStorage.getItem('productsList'));
    let i;
    for (i = 0; i < orders.length; i++)
        if (orders[i].product.productId == product.product.productId) {
            break;
        }
    orders.splice(i, 1);


    sessionStorage.setItem('productsList', JSON.stringify(orders));
    location.reload();
}


function placeOrder() {

    let orders = JSON.parse(sessionStorage.getItem('productsList'));
    let ordersProducts = [];
    orders.forEach((o) => { full(o) })

    function full(o) {
        let currentOrder = {
            ProductId: o.ProductId,
            Quantity: 1
        }
        ordersProducts.push(currentOrder);
    }

    var order = {
        OrederDate: new Date(),
        OrderSum: sum,
        UserId: JSON.parse(sessionStorage.getItem('olduser')).userId,
        OrdersProducts: ordersProducts
    }

    fetch("/api/Orders", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(order),
    }).then(response => {
        if (response.ok) {
            return response.json()
        }
        else {
            response.json().then(error => alert(JSON.stringify(error.errors)))

        }
    })
        .then(data => {
            data.orderSum = order.OrderSum
            alert(" הזמנתך נקלטה בהצלחה!!  הזמנה מספר" + " " + data.orderId)
        })
        .catch(error => { console.log(error); });
}