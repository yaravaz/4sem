var rect1 = {
    id: '1234',
    size: {
        width: 12,
        height: 20
    },
    color: '#fff'
};
var rect2 = {
    id: '12345',
    size: {
        width: 20,
        height: 30
    },
};
rect2.color = 'white';
//rect2.id = '123456'
var rect3 = {};
var rect4 = {};
var rect5 = {
    id: '123',
    size: {
        width: 10,
        height: 10
    },
    getArea: function () {
        return this.size.width * this.size.height;
    }
};
var Clock = /** @class */ (function () {
    function Clock() {
        this.time = new Date();
    }
    Clock.prototype.setTime = function (date) {
        this.time = date;
    };
    return Clock;
}());
var css = {
    border: '1pf solid black',
    marginTop: '2px',
    borderRadius: '5px'
};
