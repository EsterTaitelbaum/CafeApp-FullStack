
function showNew()
{
    document.getElementById("newUser").style.display = "block";
}



function createUser()
{
    let idu = 2;
    let type =2
    let user = {
        User_id:idu,
        Email: document.getElementById("newEmail").value,
        Password: document.getElementById("newPassword").value,
        FirstName: document.getElementById("firstName").value,
        LastName: document.getElementById("lastName").value,
        UserType: type,
    };
    fetch("api/user", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(user),
    }).then(response => {
        if (response.ok) {
            alert("המשתמש הוכנס בהצלחה");
            login(true);
        }
    
    }).catch(error => { console.log(error); });
   
     
}

function login(logAfterSign) {
    let userName;
    let pass;
    if (logAfterSign == true) {
        userName = document.getElementById("newPassword").value;
        pass = document.getElementById("newPassword").value;
    }
    else {
        userName = document.getElementById("email").value;
        pass = document.getElementById("password").value;
    }

    //fetch("api/User?login=" + userName + "&password=" + pass)
    fetch("api/User/" + userName + "/" + pass)
        .then(response => {
            if (response.status == 204)
                alert("שם המשתמש או הסיסמא אינם תקינים")
            else if (response.ok)
                return response.json();
            else
                throw new err("Status code is: " + response.status)
        })
        .then((data) => {
            sessionStorage.setItem('olduser', JSON.stringify(data));
            if (data.userType == 1) {
                location.href = 'manage.html';
            }
            else {
                alert("ברוכה הבאה ל " + data.firstName)
                //document.getElementById("login-html").innerHTML = "התחברת בהצלחה!!";
                location.href = 'Products.html';
            }


        })
        .catch(err => { console.log(err); });
}


