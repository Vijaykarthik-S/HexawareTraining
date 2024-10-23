
use BikestoresDB

--7th question

create trigger tg_stockquantityupdate on sales.orders
after insert
as
begin
update oi
set oi.quantity = oi.quantity - s.quantity
from sales.order_items oi
join production.stocks s on s.product_id = oi.product_id
join inserted i on i.order_id = oi.order_id
end

--8th question

create trigger tg_preventdeletion on sales.customers
instead of delete
as
begin
	if exists(
		select 1 from sales.orders o
		join deleted d on o.customer_id = d.customer_id
	)
	begin
	raiserror('this customer have existing orders',16,1)
	end
end













