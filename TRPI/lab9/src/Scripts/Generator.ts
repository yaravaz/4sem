type SudokuGrid = number[][];

const defaultField: SudokuGrid = [
    [5,3,0,0,7,0,0,0,0],
    [6,0,0,1,9,5,0,0,0],
    [0,9,8,0,0,0,0,6,0],
    [8,0,0,0,6,0,0,0,3],
    [4,0,0,8,0,3,0,0,1],
    [7,0,0,0,2,0,0,0,6],
    [0,6,0,0,0,0,2,8,0],
    [0,0,0,4,1,9,0,0,5],
    [0,0,0,0,8,0,0,7,9]
];

function shuffle(array: any[]): any[] {
    let currentIndex: number = array.length, temporaryValue, randomIndex: number;

    while (currentIndex !== 0) {
        randomIndex = Math.floor(Math.random() * currentIndex);
        currentIndex -= 1;

        temporaryValue = array[currentIndex];
        array[currentIndex] = array[randomIndex];
        array[randomIndex] = temporaryValue;
    }

    return array;
}

function arrangeBy(array: any[], indexes: number[]): any[] {
    let result: any[] = [];
    for (let i = 0; i < array.length; i++) {
        result[i] = array[indexes[i]];
    }
    return result;
}

function pullThird(array: any[], index: number): any[] {
    if (index === 0)
        return array.slice(0,3);
    else if (index === 1)
        return array.slice(3,6);
    else
        return array.slice(6);
}

function generatePuzzle(): SudokuGrid {
    let puzzle: SudokuGrid = defaultField.slice();

    let rowgroup1 = shuffle(puzzle.slice(0,3)),
        rowgroup2 = shuffle(puzzle.slice(3,6)),
        rowgroup3 = shuffle(puzzle.slice(6)),
        allrows = rowgroup1.concat(rowgroup2, rowgroup3),
        orderOfRows = shuffle([0,1,2]);
    rowgroup1 = pullThird(allrows, orderOfRows[0]);
    rowgroup2 = pullThird(allrows, orderOfRows[1]);
    rowgroup3 = pullThird(allrows, orderOfRows[2]);
    puzzle = rowgroup1.concat(rowgroup2, rowgroup3);

    let order1 = shuffle([0,1,2]),
        order2 = shuffle([0,1,2]),
        order3 = shuffle([0,1,2]),
        orderOfColumn = shuffle([0,1,2]);
    for (let arr = 0; arr < puzzle.length; arr++) {
        let columngroup1 = arrangeBy(puzzle[arr].slice(0,3), order1),
            columngroup2 = arrangeBy(puzzle[arr].slice(3,6), order2),
            columngroup3 = arrangeBy(puzzle[arr].slice(6), order3),
            allcolumns = columngroup1.concat(columngroup2, columngroup3);
        columngroup1 = pullThird(allcolumns, orderOfColumn[0]);
        columngroup2 = pullThird(allcolumns, orderOfColumn[1]);
        columngroup3 = pullThird(allcolumns, orderOfColumn[2]);
        puzzle[arr] = columngroup1.concat(columngroup2, columngroup3);
    }

    return puzzle;
}

export default generatePuzzle;