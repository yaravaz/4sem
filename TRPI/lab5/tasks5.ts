class Typescript {
    version: string
  
    constructor(version: string) {
        this.version = version
    }
  
    info(name: string) {
        return `[${name}]: Typescript version is ${this.version}`
    }
}
  
// class Car {
//    readonly model: string
//    readonly numberOfWheels: number = 4
//
//    constructor(theModel: string) {
//      this.model = theModel
//    }
// }
  
class Car {
    readonly numberOfWheels: number = 4
    constructor(readonly model: string) {}
}

  // Модификаторы
  
class Animal {
    protected voice: string = ''
    public color: string = 'black'
  
    constructor() {
        this.go()
    }
  
    private go() {
        console.log('Go')
    }
}
  
class Cat extends Animal {

    public setVoice(voice: string): void {
        this.voice = voice
    }

    public makeSound(): void {
        console.log(this.voice);
    }
}

  
const cat = new Cat()
cat.setVoice('test')
console.log(cat.color)
// cat.voice
  
// Абстрактные классы и методы
  
abstract class Component {
    abstract render(): void
    abstract info(): string
}
  
class AppComponent extends Component {
    render(): void {
        console.log('Component on render')
    }
  
    info(): string {
        return 'This is info';
    }
}