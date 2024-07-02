// 1-2 ЗАДАНИЕ

// создать объект по параметрам и итератор

type Product = { 
    id: number,
    size: number,
    color: string,
    price: number
}

type Shoes = {
    Boots: Product[],
    Sneakers: Product[],
    Sandals: Product[]
}

type Products = { 
    Shoes: Shoes
}

// interface Iterator<T>{
//     next(): IteratorResult<T>;
// }

// interface IteratorResult<T>{
//     done: boolean,
//     value: T
// }

function createIterator(products : Products): Iterator<Product>{
    let keysOfCategories: string[] = Object.keys(products.Shoes)
    let currentCategory: number = 0
    let currentProduct: number = 0

    return{
        next: function(): IteratorResult<Product>{
            if(currentCategory >= keysOfCategories.length){
                return{
                    done: true,
                    value: undefined
                }
            }

            let currentCategoryName: string = keysOfCategories[currentCategory]

            let keyTyped = currentCategoryName as keyof Shoes;
            let currentCategoryValue: Product[] = products.Shoes[keyTyped];

            if(currentProduct >= currentCategoryValue.length){
                currentCategory++
                currentProduct = 0
                return this.next()
            }

            let currentProductValue: Product = currentCategoryValue[currentProduct]
            currentProduct++

            return {
                done: false,
                value: currentProductValue
            }
        }
    }
}

let products: Products = {
    Shoes:{
        Boots:[
            {id: 11, size: 35, color: 'red', price: 34 },
            {id: 22, size: 37, color: 'blue', price: 35 },
            {id: 33, size: 38, color: 'red', price: 65 },
            {id: 44, size: 39, color: 'green', price: 24 },
            {id: 55, size: 40, color: 'white', price: 56 }
        ], 
        Sneakers:[
            {id: 21, size: 32, color: 'black', price: 12 },
            {id: 22, size: 33, color: 'yellow', price: 14 },
            {id: 23, size: 34, color: 'orange', price: 21 },
            {id: 24, size: 35, color: 'red', price: 24 },
            {id: 25, size: 36, color: 'white', price: 34 }
        ],
        Sandals:[
            {id: 31, size: 35, color: 'red', price: 56 },
            {id: 32, size: 34, color: 'blue', price: 76 },
            {id: 33, size: 34, color: 'grey', price: 87 },
            {id: 34, size: 45, color: 'white', price: 45 },
            {id: 35, size: 41, color: 'white', price: 67 }
        ],
    }
}

let iterator = createIterator(products)

let iteration = iterator.next()
while(!iteration.done){
    console.log(iteration.value)
    iteration = iterator.next()
}

// 3 ЗАДАНИЕ

// фильтр обуви по цене, размеру, цвету

function FilterGoods(products: Products, min: number, max: number, size: number, color: string) : number[]{
    let filtered: number[] = [];
    console.log('\n\n');

    let keys: string[] = Object.keys(products.Shoes);

    for(let key of keys){
        let keyTyped = key as keyof Shoes;
        let shoes: Product[] = products.Shoes[keyTyped];

        shoes.forEach(shoe => {
            if (shoe.price >= min && shoe.price <= max && 
                shoe.size == size && shoe.color == color){
                    filtered.push(shoe.id);
                }
        });
    }

    return filtered;
}

console.log(FilterGoods(products, 20, 60, 35, "red"))

// 4 ЗАДАНИЕ

// оптимизация добавления нового товара

function addShoes(products: Products, category: keyof Shoes, newShoes: Product[]) {
    products.Shoes[category].push(...newShoes);
}

let newBoots: Product[] = [
    {id: 1, size: 35, color: 'red', price: 34 },
    {id: 2, size: 37, color: 'blue', price: 35 },
];

addShoes(products, 'Boots', newBoots);

console.log(products);

// 5 ЗАДАНИЕ 

// добавление геттеров и сеттеров для конечной цены с учётом скидки

class ShoesPare{
    id: number
    size: number
    color: string
    discount: number
    cost: number

    constructor(id: number, size: number, color: string, cost: number, discount: number){
        this.id = id
        this.size = size
        this.color = color
        this.discount = discount
        this.cost = cost
    }

    get price():number{
        return this.cost * (1 - this.discount / 100)
    }

    set price(newPrice: number){
        this.cost = newPrice;
    }
}

let allProduct={
    Shoes:{
        Boots:[
            new ShoesPare(11, 35, 'red', 34, 10),
            new ShoesPare(12, 37, 'blue', 35, 15),
            new ShoesPare(13, 38, 'red', 65, 14),
            new ShoesPare(14, 39, 'green', 24, 10),
            new ShoesPare(15, 40, 'white', 56, 11),
        ],
        Sneakers:[
            new ShoesPare(21, 32, 'black', 12, 20),
            new ShoesPare(22, 33, 'yellow', 14, 100),
            new ShoesPare(23, 34, 'orange', 21, 25),
            new ShoesPare(24, 35, 'red', 24, 75),
            new ShoesPare(25, 36, 'white', 34, 35),
        ],
        Sandals:[
            new ShoesPare(31, 35, 'red', 56, 2),
            new ShoesPare(32, 34, 'blue', 76, 3),
            new ShoesPare(33, 34, 'grey', 87, 4),
            new ShoesPare(34, 45, 'white', 45, 2),
            new ShoesPare(35, 41, 'white', 67, 5),
        ]
    }
}
console.log(allProduct);
console.log(allProduct.Shoes.Boots[0].price)