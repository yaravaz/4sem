let phoneReg = /^\(0\d{2}\)|\+375\d{2}\d{3}-\d{2}-\d{2}$/,
    textReg = /^[a-zа-я]{1,20}$/i,
    emailReg = /^[\w]{1}[\w-\.]*@[\w-]+\.[a-z]{2,4}$/i,
    wordsReg = /^[a-zа-я]+$/i;


function formValidation(){
    let inputName = document.querySelector('.js-input-name').value,
    inputSecname = document.querySelector('.js-input-secname').value,
    inputEmail = document.querySelector('.js-input-email').value,
    inputPhone = document.querySelector('.js-input-phone').value,
    inputText = document.querySelector('.js-input-text').value,
    inputCheckbox = document.querySelector('.js-input-checkbox').checked,
    inputSelect = document.querySelector('.js-input-select').value,
    inputCourse = document.getElementById('third').checked;


    let errorName = document.querySelector('.js-error-name'),
        errorSecname = document.querySelector('.js-error-secname'),
        errorEmail = document.querySelector('.js-error-email'),
        errorPhone = document.querySelector('.js-error-phone'),
        errorText = document.querySelector('.js-error-text');

    let error = false;

    if(inputSecname != ""){
        if(!wordsReg.test(inputSecname)){
            error = true;
            errorSecname.textContent = "Фамилия должна содержать только буквы!";
        }
        else if(!textReg.test(inputSecname)){
            error = true;
            errorSecname.textContent = "Фамилия не должна превышать 20 символов!";
        }
        else errorSecname.textContent = "";
    }
    else {
        error = true;
        errorSecname.textContent = "Поле пустое";
    }

    if(inputName != ""){
        if(!wordsReg.test(inputName)){
            error = true;
            errorName.textContent = "Имя должно содержать только буквы!";
        }
        else if(!textReg.test(inputName)){
            error = true;
            errorName.textContent = "Имя не должно превышать 20 символов!";
        }
        else errorName.textContent = "";
    }
    else {
        error = true;
        errorName.textContent = "Поле пустое";
    }

    if(inputEmail != ""){
        if(!emailReg.test(inputEmail)){
            error = true;
            errorEmail.textContent = "Почта должна соответствовать формату!";
        }
        else errorEmail.textContent = "";
    }
    else {
        error = true;
        errorEmail.textContent = "Поле пустое";
    }

    if(inputPhone != ""){
        if(!phoneReg.test(inputPhone)){
            error = true;
            errorPhone.textContent = "Телефон должен соответствовать формату";
        }
        else errorPhone.textContent = "";
    }
    else {
        error = true;
        errorPhone.textContent = "Поле пустое";
    }

    if(inputText != ""){
        if(inputText.length > 250){
            error = true;
            errorText.textContent = "Превышено допустимое количество символов(250)";
        }
        else errorText.textContent = "";
    }
    else {
        error = true;
        errorText.textContent = "Поле пустое";
    }
    let result = true;
    if (!error && (inputSelect != "Минск" || !inputCourse || !inputCheckbox)) {
        result = confirm("Вы уверены в своём ответе?");
    }      
    return !error && result;
}