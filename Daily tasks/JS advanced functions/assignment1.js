const orders = [
    { id: 1, userId: 101, product: 'Laptop', amount: 999, delivered: true },
    { id: 2, userId: 102, product: 'Phone', amount: 699, delivered: false },
    { id: 3, userId: 101, product: 'Tablet', amount: 499, delivered: true },
    { id: 4, userId: 103, product: 'Monitor', amount: 199, delivered: true },
    { id: 5, userId: 104, product: 'Keyboard', amount: 49, delivered: false },
    { id: 6, userId: 102, product: 'Mouse', amount: 25, delivered: true },
    { id: 7, userId: 105, product: 'Printer', amount: 150, delivered: true },
    { id: 8, userId: 106, product: 'Webcam', amount: 75, delivered: false },
    { id: 9, userId: 107, product: 'Speakers', amount: 85, delivered: true },
    { id: 10, userId: 108, product: 'Router', amount: 120, delivered: true },
  ];

  //Only that are delivered
  const getOrdersDelivered = orders.filter((getOrd) => getOrd.delivered);
  console.log(getOrdersDelivered);

  //Fetch or Reduce the array accordingly based on UserId
  const getUserID = orders.reduce((accumulator, currentvalue) =>{
    const key = currentvalue.userId;
    if (!accumulator[key]){
      accumulator[key] = [];
    }
    accumulator[key].push(currentvalue);
    return accumulator

  },{});
  
  console.log(getUserID);
  
//Only fetch the first product of userID 102 if the delivered = true;
  const findUserId = orders.find((IdOfUser) => IdOfUser.userId == 102 && IdOfUser.delivered == true);
  console.log(findUserId);
//Fetch the total Revenue
  const TotalRevenue = orders.reduce(
    (accumulator,prodPrice) =>{ return accumulator + prodPrice.amount;},0
  );
  console.log(TotalRevenue);

