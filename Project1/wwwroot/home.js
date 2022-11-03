/// <reference path="login.js" />
var subjectsDict = {
    84: "איכות השירות",
    83: "איכות המאכל",
    82: "הטבות מועדון",
    249: "בקשות/הצעות",
    85: "עידכון פרטים",
    0: "שונות",


};

function toShort(number) {
    const int16 = new Int16Array(1)
    int16[0] = number
    return int16[0]
}

let date = new Date()
let day = date.getDate();
let month = date.getMonth() + 1;
let year = date.getFullYear();

let fullDate = `${day}.${month}.${year}.`;

function sendComplaint() {
    let complaint = {

        ClientCode: (document.getElementById("branch").value).toString(),
        SubjectCode:parseInt(document.getElementById("complaints").value),
        SubjectName: (subjectsDict[document.getElementById("complaints").value]).toString(),
        ComplaintDesc: (document.getElementById("desc").value).toString(),
        UpdateDate: (fullDate).toString(),
        LetterDesc: (document.getElementById("desc").value).toString(),
        Summary: ""

        //ClientCode: "aaa",
        //SubjectCode:777,
        //SubjectName: "aaa",
        //ComplaintDesc: "aaa",
        //UpdateDate: "aaa",
        //LetterDesc: "aaa",
        //Summary: ""
    };
    
    fetch("api/ComplaintController1", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(complaint),
    }).then(response => {
        if (response.ok) {
            alert("התלונה הוכנסה בהצלחה");
        }

    }).catch(error => { console.log(error); });

}


