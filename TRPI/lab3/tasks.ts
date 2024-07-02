// 1 task

function createPhoneNumber(numbers: number[]): string{
    const code: string = numbers.slice(0, 3).join('')
    const firstStr: string = numbers.slice(3, 6).join('')
    const secStr: string = numbers.slice(6).join('')
    return `(${code}) ${firstStr}-${secStr}`
}

const numbers: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 0]
const phoneNumber: string = createPhoneNumber(numbers)
console.log(phoneNumber)

// 2 task

function sum(number: number): number{
    if(number < 0){
        return 0
    }
    else{
        let sum: number = 0
        for(let i:number = 0; i < number; i++){
            if(i % 3 == 0 || i % 5 == 0){
                sum += i
            }
        }
        return sum
    }
}

console.log(sum(20))    

// 3 task 

function moveArray(array:number[], k:number ): number[]{
    const length: number = array.length
    const newArray: number[] = new Array(length)
    for(let i: number = 0; i < length; i++){
        const index: number = (i + k) % length
        newArray[index] = array[i]
    }
    return newArray
}

console.log(moveArray([1, 2, 3, 4, 5, 6, 7], 3))

// 4 task

function findMedian(array1: number[], array2: number[]): number{
    const newArr: number[] = array1.concat(array2)
    const length: number = newArr.length
    newArr.sort(function(a,b){return a - b})
    if(length % 2 != 0){
        return newArr[Math.floor(length/2)]
    }
    else{
        const index: number = Math.floor(length/2)
        return (newArr[index] + newArr[index - 1])/2
    }

}

console.log(findMedian([1,3], [2]))
console.log(findMedian([1,2], [3,4]))
console.log(findMedian([1, 2, 5], [3, 4, 8]))