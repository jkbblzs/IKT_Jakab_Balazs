document.getElementById('button2').onclick=function (){
    var delNumber=document.getElementById('number2').value;
    delCustomer(delNumber)
}

async function delCustomer(delNumber){

    var url='http://localhost:60227/Service1.svc/deleteCustomer/'+delNumber;
    var delFetch=await fetch(url,{
        method: "DELETE",
        headers:{
            'Content-Type': 'application/json'
        }
    });

    if(!delFetch.ok){
        alert("DELETE végpont hiba!")
        return;
    }

    var httpMessage=await delFetch.json();

    getCustomers();
}

document.getElementById('form1').onsubmit=function (event){
  
    event.preventDefault();
    var nev=event.target.elements.nev.value;
    var kor=event.target.elements.kor.value;
    var varos=event.target.elements.varos.value;

    var bodyCustomer=JSON.stringify({
      Name: nev,
      Age: kor,
      City: varos
    });

    putCustomer(bodyCustomer);
}


async function putCustomer(bodyCustomer){
   
    var url='http://localhost:60227/Service1.svc/putCustomer';
    var putUser=await fetch(url,{
        method: "POST",
        body: bodyCustomer,
        headers: {
            'Content-Type': 'application/json'
        }
    })

    if(!putUser.ok){
        alert("POST végpont hiba!");
        return;
    }

    var httpMessage=await putUser.json();

    alert(httpMessage);

    getCustomers();
} 

async function getCustomers(){

    var url='http://localhost:60227/Service1.svc/getcustomers';
    var userList = await fetch(url); 

    if(!userList.ok){
        alert("GET végpont hiba!");
        return;
    }

    var users=await userList.json();

    renderUsers(users);

}

function renderUsers(users){
    var contentText='';

    for (var item of users) {
        contentText+=`<li>
        ${item.Id} 
        ${item.Name}
        ${item.Age}
        ${item.City}<br>
        </li>`;
    }

    document.getElementById("uList").innerHTML="<ul>"+contentText+"</ul>"
}

getCustomers();