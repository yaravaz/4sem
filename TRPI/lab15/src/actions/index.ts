export type Action = {
    type: string,
    i? : number,
    j? : number,
    n? : number,
}

export const generateField = ()=>({
    type: CREATE_FIELD
})

export const getHint = ()=>({
    type: GET_HINT
})

export const changeCell = (i:number, j:number, n:number)=>({
    type: SET_CELL,
    i,
    j,
    n
})

export const setNumber = (n:number)=>({
    type: SET_NUMBER,
    n
})

export const CREATE_FIELD = "CREATE_FIELD";
export const SET_CELL = "SET_CELL";
export const SET_NUMBER = "SET_NUMBER";
export const GET_HINT = "GET_HINT";