

const passwordField = document.querySelector("[name=password]");
const passwordField2 = document.querySelector("[name=password2]");

//metodo para validar contrasena\

passwordField.addEventListener("blur", function (e) {

    const field = e.target.value;
    let fieldLenght = field.trim().length;
    const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])([A-Za-z\d$@$!%*?&]|[^ ]){7,16}$/;


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
//metodo para validar contrasena 2\
passwordField2.addEventListener("blur", function (e) {

    const field = e.target.value;
    let fieldLenght = field.trim().length;
    const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])([A-Za-z\d$@$!%*?&]|[^ ]){7,16}$/;
    if (fieldLenght > 5 && regex.test(passwordField2.value) && fieldLenght < 16) {
        passwordField2.classList.remove("invalid")
        passwordField2.nextElementSibling.classList.remove("error")
        passwordField2.nextElementSibling.innerText = ""

    } else if (fieldLenght < 5 || !regex.test(passwordField2.value) || fieldLenght > 16) {
        passwordField2.classList.add("invalid")
        passwordField2.nextElementSibling.classList.add("error")
        passwordField2.nextElementSibling.innerText = "(Contraseña debe contener mayusculas, minusculas, numeros, caracter especial, mayor a 8 caracteres, menor de 16 caracteres)"

    }
});

//metodo para validar que sean iguales\


       

