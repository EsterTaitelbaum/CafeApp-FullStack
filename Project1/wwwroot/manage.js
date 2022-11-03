//function getGraph() {

//}

function getAnomalies() {
    var numBranch = document.getElementById("branch_ano").value;
    var startDate = document.getElementById("date1_ano").value;
    var endDate = document.getElementById("date2_ano").value;
    fetch("http://127.0.0.1:5000/Anomalies/" + numBranch + "/" + startDate + "/" + endDate)
        .then(fetch("anomalyMsg.txt")
            .then((response) => {
                return response.text();
            })
            .then((text) => {
                document.getElementById("anomalyMsg").innerText = text
                document.getElementById("anomalyMsg").style.display = 'block'
            }))
}

function getGraph() {
    let subject = document.getElementById("subject").value
    let start = document.getElementById("date1").value
    let end = document.getElementById("date2").value
    let bins = document.getElementById("bins").value
    fetch("http://127.0.0.1:5000/graph/" + subject + "/" + start + "/" + end + "/" + bins)
        .then(document.getElementById("graph").src = "images/fig.png")
}

function searchData() {
    request = document.getElementById("searchSentence").value
    fetch("http://127.0.0.1:5000/complaints_information/" + request)

    fetch("complaintsInfo.txt")
        .then((response) => {
            return response.text();
        })
        .then((text) => {
            document.getElementById("complaintsInfo").innerText = text
            document.getElementById("complaintsInfo").style.display = 'block'
        });
}

function common_complaints() {
    fetch("http://127.0.0.1:5000/common_complaints")
    fetch("common.txt")
        .then((response) => {
            return response.text();
        })
        .then((text) => {
            document.getElementById("commonMsg").innerText = text
            document.getElementById("commonMsg").style.display = 'block'
        })
}


function show_research() {
    document.getElementById("manage").style.display = 'none';
    document.getElementById("research").style.display = 'block';
    document.getElementById("tab1").checked = true;

}

function show_manage() {
    document.getElementById("manage").style.display = 'block';
    document.getElementById("research").style.display = 'none';
    document.getElementById("tab8").checked = true;
}

function addProduct() {
    let product = {
        ProductName: document.getElementById("ProductName").value,
        CategoryId: parseInt(document.getElementById("categoryID").value),
        Price: parseInt(document.getElementById("price").value),
        Description: document.getElementById("description").value,
        ImageName: document.getElementById("image").value
    }
    fetch("api/Products", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(product),
    }).then(response => {
        if (response.ok) {
            alert("המוצר נוסף בהצלחה");
        }

    }).catch(error => { console.log(error); });

}
function addCategory() {
    let Category = {
        CategoryName: document.getElementById("CategoryName").value
    }
    fetch("api/Category", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(Category),
    }).then(response => {
        if (response.ok) {
            alert("הקטגוריה נוספה בהצלחה");
        }

    }).catch(error => { console.log(error); });

}