
let user = JSON.parse(sessionStorage.getItem('olduser'));

let mess = document.getElementById("p");
mess.innerHTML = "התחברת בהצלחה" + JSON.parse(sessionStorage.getItem('olduser')).firstName + " שלום, "

let update = document.getElementById("update");
update.addEventListener('click', toUpdate)

function toUpdate() {
    let s = document.getElementById("span");
    s.style.display = "block";
}

let up = document.getElementById("up");
up.addEventListener('click', updateDetailes)

function updateDetailes() {
    let id = JSON.parse(sessionStorage.getItem('olduser')).id;
    let user = {
        Email: document.getElementById("EmailForUpdate").value,
        Password: document.getElementById("PasswordForUpdate").value,

        FirstName: document.getElementById("firstNameForUpdate").value,
        LastName: document.getElementById("lastNameForUpdate").value,
    };
    let a = JSON.parse(sessionStorage.getItem('olduser'));
    fetch("api/User/" + a.userId, {
        method: "PUT",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(user),
    }).then(response => {
        if (response.status == 200)
            alert("הפרטים עודכנו בהצלחה")
        else if (response.status == 204)
            alert("שם המשתמש או הסיסמא אינם תקינים")
        else
            alert("ארעה שגיאה, נסה שנית")


    }).catch(error => { console.log(error); });
}



    document.getElementById("buy").addEventListener('click', Buy);
    function Buy() {
        window.location.href = "Products.html";
    }
