const emailField = document.querySelector("[name=email]");
const passwordField = document.querySelector("[name=password]");
const formulario = document.getElementById('formulario');
const inputs = document.querySelectorAll('#formulario input');
const nombreField = document.querySelector("[name=nombre]");
const apellidosField = document.querySelector("[name=apellidos]");
const cedulaField = document.querySelector("[name=cedula]");
const telefonoField = document.querySelector("[name=telefono]");
const tipoUsuarioField = document.querySelector("[name=tipoUsuario]");


const campos = {
    nombre: false,
    apellidos: false,
    contrasenna: false,
    cedula: false,
    email: false,
    tipoUsuario: false,
    telefono: false

}

const validarFormulario = (e) => {
    const field = e.target.value;
    let fieldLenght = field.trim().length;
    switch (e.target.name) {
        
        case 'nombre':
            
            if (fieldLenght > 0) {
                nombreField.classList.remove("invalid")
                nombreField.nextElementSibling.classList.remove("error")
                nombreField.nextElementSibling.innerText = ""
                campos.nombre = true
            } else {
                nombreField.classList.add("invalid")
                nombreField.nextElementSibling.classList.add("error")
                nombreField.nextElementSibling.innerText = ""
                
            };
            break;
        case 'apellidos':
            if (fieldLenght > 0) {
                apellidosField.classList.remove("invalid")
                apellidosField.nextElementSibling.classList.remove("error")
                apellidosField.nextElementSibling.innerText = ""
                campos.apellidos = true
            } else {
                apellidosField.classList.add("invalid")
                apellidosField.nextElementSibling.classList.add("error")
                apellidosField.nextElementSibling.innerText = ""
            };
            break;
        case 'cedula':
            if (fieldLenght > 0) {
                cedulaField.classList.remove("invalid")
                cedulaField.nextElementSibling.classList.remove("error")
                cedulaField.nextElementSibling.innerText = ""
                campos.cedula = true
            } else {
                cedulaField.classList.add("invalid")
                cedulaField.nextElementSibling.classList.add("error")
                cedulaField.nextElementSibling.innerText = ""
            };
            break;
        case 'telefono':
            if (fieldLenght > 0) {
                telefonoField.classList.remove("invalid")
                telefonoField.nextElementSibling.classList.remove("error")
                telefonoField.nextElementSibling.innerText = ""
                campos.telefono = true
            } else {
                telefonoField.classList.add("invalid")
                telefonoField.nextElementSibling.classList.add("error")
                telefonoField.nextElementSibling.innerText = ""
            };
            break;
        case 'tipoUsuario':
            if (fieldLenght > 0) {
                tipoUsuarioField.classList.remove("invalid")
                tipoUsuarioField.nextElementSibling.classList.remove("error")
                tipoUsuarioField.nextElementSibling.innerText = ""
                campos.tipoUsuario = true
            } else {
                tipoUsuarioField.classList.add("invalid")
                tipoUsuarioField.nextElementSibling.classList.add("error")
                tipoUsuarioField.nextElementSibling.innerText = ""
            };
            break;
       
    }

}

inputs.forEach((input) => {

    input.addEventListener('keyup', validarFormulario);
    input.addEventListener('blur', validarFormulario);
});
  



emailField.addEventListener("blur", function (e) {

    const field = e.target.value;
    let fieldLenght = field.trim().length;
    const regex = new RegExp(/^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/);

    if (fieldLenght > 5 && regex.test(emailField.value)) {
        emailField.classList.remove("invalid")
        emailField.nextElementSibling.classList.remove("error")
        emailField.nextElementSibling.innerText = ""
        campos.email = true

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
    const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])([A-Za-z\d$@$!%*?&]|[^ ]){7,16}$/;


    if (fieldLenght > 5 && regex.test(passwordField.value) && fieldLenght < 16) {
        passwordField.classList.remove("invalid")
        passwordField.nextElementSibling.classList.remove("error")
        passwordField.nextElementSibling.innerText = ""
        campos.contrasenna = true

    } else if (fieldLenght < 5 || !regex.test(passwordField.value) || fieldLenght > 16) {
        passwordField.classList.add("invalid")
        passwordField.nextElementSibling.classList.add("error")
        passwordField.nextElementSibling.innerText = "(Contraseña debe contener mayusculas, minusculas, numeros, caracter especial, mayor a 8 caracteres, menor de 16 caracteres)"

    }
});

//metodo para validar todo el form con el boton de registrar
//formulario.addEventListener('submit', (e) => {
//    e.preventDefault();
//    if (campos.nombre && campos.apellidos && campos.cedula & campos.email && campos.telefono && campos.tipoUsuario && campos.contrasenna) {
//        formulario.reset();
//        document.getElementById('formulario__mensaje-exito').classList.add('formulario__mensaje-exito-activo');
//        setTimeout(() => {
//            document.getElementById('formulario__mensaje-exito').classList.remove('formulario__mensaje-exito-activo');

//        }, 5000);

//    }

//})