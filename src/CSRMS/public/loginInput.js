const input = document.querySelector("div.input_wrapper input[name='password']"); 
const inputIcon = document.querySelector(".input_icon");
const loginButton = document.getElementById("login"); 

inputIcon.addEventListener("click", (e)=>{
    e.preventDefault(); 

    inputIcon.setAttribute(
        'src', 
        input.getAttribute('type') === 'password' ?
        'eye-off.svg'
          :
        'eye.svg'
    ); 
    

    input.setAttribute(
        'type', 
        input.getAttribute('type') === 'password' ? 
        'text'
         :
        'password'
    ); 
    
}); 

input.addEventListener("blur", (e)=> {
    e.preventDefault(); 
    input.setAttribute('type', 'password'); 

    inputIcon.setAttribute(
        'src', 
        input.getAttribute('type') === 'password' ?
        'eye.svg'
          :
        'eye.svg'
    ); 
}); 

loginButton.addEventListener("click", (e) => {
    e.preventDefault(); 

    let username = document.forms["login"]["username"].value; 
    let password = document.forms["login"]["password"].value;
    
    console.log(username); 
    console.log(password); 

    localStorage.setItem("username", username); 
    localStorage.setItem("password", password); 
    window.location.href = "/dashboard.html"

}); 



