var text = document.querySelector(".endOfGame").textContent,
    result = document.querySelector(".result").value;

function doGame(){
    let height = document.querySelector(".height").value,
        width = document.querySelector(".width").value,
        diametr = document.querySelector(".diametr").value,
        ball = document.querySelector(".ball");

    if((+height < diametr) || (width - diametr < 40) || (+diametr <= 0)){
        alert("Неподходящие размеры");
        return false;
    }

    for(let i=1; i <= 3; i++){
        let image = document.querySelector(".image"+i);

        image.width = width; // max: 468
        image.height = height;
    }

    ball.width = diametr;
    let image1 = document.querySelector(".image1");
    let cup = image1.getBoundingClientRect();
    moveBall(cup);
    
    return false;
}
function moveBall(x){
    let ball = document.querySelector(".ball");
    ball.style.right = "0px";
    let ballXY = ball.getBoundingClientRect();
    ball.style.right = (ballXY.left - x.left) - 35 + "px";
}

function upCup(target){

    let height = document.querySelector(".height").value,
        width = document.querySelector(".width").value,
        diametr = document.querySelector(".diametr").value;

    if((width - diametr < 40) || (+height < diametr) || (+diametr <= 0)){
        alert("Неподходящие размеры");
        return false;
    }
    
    let rdmNum = Math.ceil(Math.random()*3);
    console.log(rdmNum);

    let image1 = document.querySelector(".image1"),
        image2 = document.querySelector(".image2"),
        image3 = document.querySelector(".image3");

    let flag;

    let cup = document.querySelector("."+target.className);
    cup.className+=" upCup";

    setTimeout(function() {
        cup.className = cup.className.slice(0, -6);
        
    }, 2000);

    switch(rdmNum){
        case 1:{
            for(let i = 0; i < 2; i++){
                let cup1 = image1.getBoundingClientRect();
                flag = 1;
                moveBall(cup1);
            }
            break;
        }
        case 2:{
            for(let i = 0; i < 2; i++){
                let cup2 = image2.getBoundingClientRect(); 
                flag = 2;
                moveBall(cup2);
            }
            break;
        }
        case 3:{
            for(let i = 0; i < 2; i++){
                let cup3 = image3.getBoundingClientRect(); 
                flag = 3;
                moveBall(cup3);
            }
            break;
        }
    }
   

    if(flag == cup.className[5]){
        text = "Верно!";
        result++;
    }
    else{
        text = "Неверно!";
        result--;
    }

    document.querySelector(".endOfGame").textContent = text;
    document.querySelector(".result").value = result;

    return false;
}

function funcClear(){
    text = "";
    result = 0;

    document.querySelector(".endOfGame").textContent = text;
    document.querySelector(".result").value = result;
}