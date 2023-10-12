
const password = document.getElementById('Contraseña');
const confirmPassword = document.getElementById('ConfirmarContraseña');


function validatePassword() {
  const passwordRegex = /^(?=.[a-z])(?=.[A-Z])(?=.[0-9])(?=.[!@#$%]).{8,24}$/;
  
  if(password.value !== confirmPassword.value) {
    alert('Las contraseñas no coinciden');
    return false;
  }

  if(!passwordRegex.test(password.value)) {
    alert('La contraseña debe contener al menos un caracter especial, una mayúscula, un número y 8 caracteres');
    return false;
  }

  return true;
}

const form = document.getElementById('formregistro');
form.addEventListener('submit', (e) => {
  e.preventDefault();
  
  if(!validatePassword()) {
    return; 
  }

  form.submit();
});