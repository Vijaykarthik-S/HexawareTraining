

/* 1.
create proc uspProductlists
as 
begin
select * from production.products
end

exec uspProductlists

alter proc uspProductlists
as
begin
select product_id,product_name,list_price from production.products 
order by list_price desc
end*/

/*2.
CREATE PROCEDURE GetCustomersByProduct
    @ProductID INT
AS
BEGIN
    SELECT 
        c.Customer_id,CONCAT(c.first_name,'',c.last_name) as
        c.CustomerName, 
        o.PurchaseDate
    FROM 
        sales.customers c
    INNER JOIN 
        Orders o ON c.CustomerID = o.CustomerID
    INNER JOIN 
        Order_items oi ON o.OrderID = oi.OrderID
    WHERE 
        oi.Product_ID = @Product_ID
END
  */


/*5.
create function totalsales(@product_id int)
returns @totalsalestable table(
	product_id int,
	totalsalesprice decimal(20,2)
)
as
begin
insert into @totalsalestable 
select product_id, sum(quantity*list_price) as totalsalesprice from sales.order_items
group by product_id
return
end */

--select * from totalsales()

--6.
create function totalsaleslist(@customer_id int)
returns @totalsalesonlist table(
	 Customer_id int,
	 Customer_name varchar(50),
	 total_amount decimal(20,2)

)
as
begin
insert into @totalsalesonlist
select c.customer_id,concat(c.first_name,' ', c.last_name) as Customer_name, sum(oi.quantity * oi.list_price) as total_amount from sales.customers c
join sales.orders o on c.customer_id = o.customer_id
join sales.order_items oi on o.order_id = oi.order_id
group by c.customer_id, c.first_name, c.last_name
return
end

select * from totalsaleslist(5)  



