


document.addEventListener("DOMContentLoaded", function () {
    const input = document.querySelector("div.input_wrapper input[placeholder='Your Password']");
    const inputIcon = document.querySelector(".input_icon");
    const loginButton = document.getElementsByName('username');
   

    inputIcon.addEventListener("click", (e) => {
        e.preventDefault();

        inputIcon.setAttribute(
            'src',
            input.getAttribute('type') === 'password' ?
                '../Public/Images/eye-off.svg'
                :
                '../Public/Images/eye.svg'
        );


        input.setAttribute(
            'type',
            input.getAttribute('type') === 'password' ?
                'text'
                :
                'password'
        );

    });

    input.addEventListener("blur", (e) => {
        e.preventDefault();
        input.setAttribute('type', 'password');

        inputIcon.setAttribute(
            'src',
            input.getAttribute('type') === 'password' ?
                '../Public/Images/eye.svg'
                :
                '../Public/Images/eye.svg'
        );
    });


}); 




