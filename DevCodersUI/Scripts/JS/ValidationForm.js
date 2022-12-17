

const emailField = document.querySelector("[name=email]");
const passwordField = document.querySelector("[name=password]");
const formulario = document.getElementById('formulario');
const inputs = document.querySelectorAll('#formulario input');

const nombreField = document.querySelector("[name=email]");
const apellidoField = document.querySelector("[name=email]");
const cedulaField = document.querySelector("[name=email]");
const telefonoField = document.querySelector("[name=email]");
const tipoUsuarioField = document.querySelector("[name=email]");


//metodo para validar correo

emailField.addEventListener("blur", function (e) {

    const field = e.target.value;
    let fieldLenght = field.trim().length;
    const regex = new RegExp(/^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/);

    if (fieldLenght > 5  && regex.test(emailField.value)) {
        emailField.classList.remove("invalid")
        emailField.nextElementSibling.classList.remove("error")
        emailField.nextElementSibling.innerText = ""
        
    } else {
        emailField.classList.add("invalid")
        emailField.nextElementSibling.classList.add("error")
        emailField.nextElementSibling.innerText = "(Correo electronico es requerido)"
        
    }
});


//metodo para validar contrasena\

passwordField.addEventListener("blur", function (e) {

    const field = e.target.value;
    let fieldLenght = field.trim().length;
    const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*$?&])([A-Za-z\d$@$!%*?&]|[^ ]){7,16}$/;


    if (fieldLenght > 5 && regex.test(passwordField.value) && fieldLenght < 16) {
        passwordField.classList.remove("invalid")
        passwordField.nextElementSibling.classList.remove("error")
        passwordField.nextElementSibling.innerText = ""
        
    } else if (fieldLenght < 5 || !regex.test(passwordField.value) || fieldLenght > 16){
        passwordField.classList.add("invalid")
        passwordField.nextElementSibling.classList.add("error")
        passwordField.nextElementSibling.innerText = "(Contraseña debe contener mayusculas, minusculas, numeros, caracter especial, mayor a 8 caracteres, menor de 16 caracteres)"
   
    }
});

