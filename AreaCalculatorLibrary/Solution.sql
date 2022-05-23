create table dbo.products
(
    id           int,
    product_name nvarchar(100)
);

create table dbo.categories
(
    id            int,
    category_name nvarchar(100)
);

create table dbo.prodcats
(
    prod_id int,
    cat_id  int
);

-- select products without categories
select
    id as prod_id, product_name, '' as category_name 
from
    dbo.products
where
    not id = any(
        select prod_id
        from dbo.prodcats
    )
union
-- select all pairs product-category
select
       prod_id, product_name, category_name
from
    dbo.prodcats pc
        left join
        dbo.categories ct
            on pc.cat_id = ct.id
        left join
        dbo.products pr
            on pc.prod_id = pr.id