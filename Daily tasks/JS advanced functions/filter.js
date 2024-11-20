const nums = [1,2,3,4,5,6,7,8,9,10]
const even = nums.filter((num)=> num %2==0);
console.log(even);

const users = [
    {id : 1, name : "Karthi", age : 21},
    {id : 2, name : "Ganesh", age : 22},
    {id : 3, name : "Brock", age : 20},
    {id : 4, name : "Jesse", age : 18}
        
];
const teenuser = users.filter((teens) => teens.age>=18 && teens.age<=21);
console.log(teenuser);

const products = [
    {id : 1, name : "Laptop", details : {price : 50000, instock : true}},
    {id : 2, name : "Smart Watch", details : {price : 10000, instock : true}},
    {id : 3, name : "Nano armor", details : {price : 500000, instock : false}}
];

const getprod = products.filter((prod) => prod.details.instock);
console.log(getprod);