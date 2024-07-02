
function Copy(matrix:number[][]){
    return matrix.map(row => [...row]);
}

function rowError(matrix:number[][], row:number):void{
    for (let i:number = 0; i < 9; i++) {
        matrix[row][i] = (Math.abs(matrix[row][i]) + 10)  * -1;
    }
}
function colError(matrix:number[][], col:number):void{
    for (let i:number = 0; i < 9; i++) {
        matrix[i][col] = (Math.abs(matrix[i][col]) + 10)  * -1;
    }
}

function blockError(matrix:number[][], row:number, col:number){
    for (let i = 0; i < 3; i++) {
        for (let j = 0; j < 3; j++) {
            matrix[i + row][j + col] = (Math.abs(matrix[i + row][j + col])  + 10)  * -1;
        }
    }
}

function errorLocate(matrix:number[][], correctMatrix:number[][], row: number, col: number):number[][]{
    const newField:number[][] = matrix.map(row => [...row]);
    const startRow:number = row - row % 3;
    const startCol:number = col - col % 3;
    for (let i:number = 0; i < 3; i++) {
        for (let j:number = 0; j < 3; j++) {
            if (correctMatrix[i + startRow][j + startCol] === Math.abs(matrix[row][col]) && !(i + startRow === row && j + startCol === col)) {
                blockError(newField, startRow, startCol);
            }
        }
    }

    for (let i:number = 0; i < 9; i++) {
        if (newField[row][i] > 0 && correctMatrix[row][i] === Math.abs(matrix[row][col]) && i !== col) {
            rowError(newField, row);
        }
        if (newField[i][col] > 0 && correctMatrix[i][col] === Math.abs(matrix[row][col]) && i !== row) {
            colError(newField, col);
        }
    }
    return newField;
}

function adjustMatrix(correctMatrix:number[][], matrix:number[][]):number[][] {
    const newField:number[][] = Copy(matrix);
    const state:number[][] = new Array(9).fill(0).map(() => new Array(9).fill(1));
    for (let i = 0; i < correctMatrix.length; i++) {
        for (let j = 0; j < correctMatrix[i].length; j++) {
            if (correctMatrix[i][j] !== newField[i][j]) {
                uniteStateMatrix(state, createStateMatrix(errorLocate(newField, correctMatrix, i, j), correctMatrix))
            }
        }
    }
    uniteStateMatrix(state, createStateMatrix(newField, correctMatrix))
    return state;
}


function uniteStateMatrix(matrix:number[][], newMatrix:number[][]){
    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[i].length; j++) {
            if(matrix[i][j] >= 0)
                matrix[i][j] = newMatrix[i][j];
        }
    }
}

function createStateMatrix(matrix:number[][], correctMatrix:number[][]):number[][] {
    const newField:number[][] = Copy(matrix);
    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[i].length; j++) {
            if (matrix[i][j] > 0)
                newField[i][j] = 1;
            if(matrix[i][j] < 0)
                newField[i][j] = -1;
            if(Math.abs(matrix[i][j])%10 === correctMatrix[i][j])
                newField[i][j] *= 2;
        }
    }
    return newField;
}

export {adjustMatrix, Copy};