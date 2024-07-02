var isFetching = true;
var isLoading = false;
var int = 42;
//int = ''
var float = 4.2;
var num = 3e10;
var message = 'Hello Typescript';
var numberArray = [1, 1, 2, 3, 5, 8, 13];
var numberArray2 = [1, 1, 2, 3, 5, 8, 13];
var words = ['Hello', 'Typescript'];
// tuple
var contact = ['Ivan', 1234567];
// any
var variable = 42;
variable = 'new string';
variable = [];
function sayMyName(name) {
    console.log(name);
}
sayMyName('Ivan');
// never
function throwError(message) {
    throw new Error(message);
}
function infinite() {
    while (true) { }
}
var login = 'admin';
var id1 = 1234;
var id2 = 'dfghj';
