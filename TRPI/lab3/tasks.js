// 1 task
function createPhoneNumber(numbers) {
    var code = numbers.slice(0, 3).join('');
    var firstStr = numbers.slice(3, 6).join('');
    var secStr = numbers.slice(6).join('');
    return "(".concat(code, ") ").concat(firstStr, "-").concat(secStr);
}
var numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 0];
var phoneNumber = createPhoneNumber(numbers);
console.log(phoneNumber);
// 2 task
function sum(number) {
    if (number < 0) {
        return 0;
    }
    else {
        var sum_1 = 0;
        for (var i = 0; i < number; i++) {
            if (i % 3 == 0 || i % 5 == 0) {
                sum_1 += i;
            }
        }
        return sum_1;
    }
}
console.log(sum(20));
// 3 task 
function moveArray(array, k) {
    var length = array.length;
    var newArray = new Array(length);
    for (var i = 0; i < length; i++) {
        var index = (i + k) % length;
        newArray[index] = array[i];
    }
    return newArray;
}
console.log(moveArray([1, 2, 3, 4, 5, 6, 7], 3));
// 4 task
function findMedian(array1, array2) {
    var newArr = array1.concat(array2);
    var length = newArr.length;
    newArr.sort(function (a, b) { return a - b; });
    if (length % 2 != 0) {
        return newArr[Math.floor(length / 2)];
    }
    else {
        var index = Math.floor(length / 2);
        return (newArr[index] + newArr[index - 1]) / 2;
    }
}
console.log(findMedian([1, 3], [2]));
console.log(findMedian([1, 2], [3, 4]));
console.log(findMedian([1, 2, 5], [3, 4, 8]));
