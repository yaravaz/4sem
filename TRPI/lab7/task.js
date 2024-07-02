
// task1

let myPromise = new Promise(function(resolve, reject){

    setTimeout(() => resolve(Math.floor(Math.random()*10)), 3000);

});

myPromise.then(
    result => console.log(result)
);

// task2

function myFunction(delay){
    
    myPromise = new Promise(function(resolve, reject){

        setTimeout(() => resolve(Math.floor(Math.random()*10)), delay);
    
    });

    return myPromise;
}

Promise.all([
    myFunction(3000),
    myFunction(4000),
    myFunction(6000)
]).then(
    (result) => console.log(result)
)

// task3

let pr = new Promise((res,rej) => {
    rej('ku')
})

pr
    .then(() => console.log(1))
    .catch(() => console.log(2))
    .catch(() => console.log(3))
    .then(() => console.log(4))
    .then(() => console.log(5))


// task4

new Promise(function(resolve, reject) {

    setTimeout(() => resolve(21), 1000);
  
  }).then(function(result) {
  
    console.log(result);
    return result * 2;
  
  }).then(function(result) {
    console.log(result)
    return;
  })

// task5 

async function asyncAwait(){
    try{
        let result = await new Promise(function(resolve, reject) {

            setTimeout(() => resolve(21), 1000);
          
          });
        
        console.log(result);

        result*=2;

        console.log(result);
    }
    catch(error){
        console.log(error);
    }
}

asyncAwait();