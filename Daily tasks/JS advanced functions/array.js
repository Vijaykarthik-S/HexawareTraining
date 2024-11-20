const arr = [10,"Jom",30, "Snake"]
arr.forEach((data) => {
    console.log(data);
});

const arr1 = [
    {id:1, name :"Thorfinn" },
    {id:2, name :"Askeladd" },
    {id:3, name :"Canute" }
];
arr1.forEach((dat) =>{
    console.log(`ID:${dat.id}, Name:${dat.name}`);
});

//Map
const num = [30,40,50,60,70]
const doublednum = num.map((number)=> number*2);
console.log(doublednum);