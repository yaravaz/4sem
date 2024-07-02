const isFetching: boolean = true
const isLoading: boolean = false

let int: number = 42
//int = ''
const float: number = 4.2
const num: number = 3e10

const message: string = 'Hello Typescript'

const numberArray: number[] = [1, 1, 2, 3, 5, 8, 13]
const numberArray2: Array<number> = [1, 1, 2, 3, 5, 8, 13]

const words: string[] = ['Hello', 'Typescript']

// tuple
const contact: [string, number] = ['Ivan', 1234567]

// any
let variable: any = 42
variable = 'new string'
variable = []

function sayMyName(name: string): void{
    console.log(name)
}
sayMyName('Ivan')

// never
function throwError(message: string): never{
    throw new Error(message)
}

function infinite(): never{
    while(true){}
}

// type
type Login = string

const login: Login = 'admin'
//const login2: Login = 2

type ID = string | number
const id1: ID = 1234
const id2: ID = 'dfghj'
//const id3: ID = true

// null | undefined
type SomeType = string | null | undefined