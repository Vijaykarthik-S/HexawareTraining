const numbers = [1,2,3,4,5];
const sum = numbers.reduce((accumulator, currentvalue)=>accumulator+currentvalue,0);

console.log(sum);

const nestedarray = [
    [1,2],
    [3,4],
    [5,6],
    [7,8],
];
const flatterenedarray = nestedarray.reduce((accumulator,currentvalue)=> 
    accumulator.concat(currentvalue),[]
);
console.log(flatterenedarray);

const users = [
    {id : 1, name : "Karthi", age : 21, city:"Chennai"},
    {id : 2, name : "Ganesh", age : 22, city:"Chennai"},
    {id : 3, name : "Brock", age : 20, city:"Texas"},
    {id : 4, name : "Jesse", age : 18, city:"Albuquerque"}
];
const groupbycity = users.reduce((accumulator,currentvalue) => {
    const key = currentvalue.city;
    if (!accumulator[key]){
        accumulator[key] = [];
    }
    accumulator[key].push(currentvalue);
    return accumulator
}, {});
console.log(groupbycity);

const cart = [
    {product : "Laptop", price : 49999, quantity : 1},
    {product : "Pen Drive", price : 499, quantity : 5},
    {product : "Note", price : 49, quantity : 10}
];

const totalpricecart = cart.reduce((accumulator,item) => {
    return accumulator + item.price* item.quantity;
},0

);
console.log(totalpricecart);
