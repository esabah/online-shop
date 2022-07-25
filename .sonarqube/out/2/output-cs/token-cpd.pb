Ú
ZC:\Projects\Sendeo\Assestment\online-shop\ProductMicroservice\Business\Dtos\CategoryDto.cs
	namespace 	
ProductMicroservice
 
. 
Business &
.& '
Dtos' +
{ 
public 

class 
CategoryDto 
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
[ 	
	MaxLength	 
( 
$num 
) 
] 
[		 	
Required			 
]		 
public

 
string

 
Description

 !
{

" #
get

$ '
;

' (
set

) ,
;

, -
}

. /
=

0 1
null

2 6
!

6 7
;

7 8
} 
} µ
YC:\Projects\Sendeo\Assestment\online-shop\ProductMicroservice\Business\Dtos\ProductDto.cs
	namespace 	
ProductMicroservice
 
. 
Business &
.& '
Dtos' +
{ 
public 

class 

ProductDto 
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
[ 	
	MaxLength	 
( 
$num 
) 
] 
[		 	
Required			 
]		 
public

 
string

 
Name

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
=

) *
null

+ /
!

/ 0
;

0 1
[ 	
	MaxLength	 
( 
$num 
) 
] 
[ 	
Required	 
] 
public 
string 
? 
Description "
{# $
get% (
;( )
set* -
;- .
}/ 0
[ 	
Required	 
] 
public 
decimal 
Price 
{ 
get "
;" #
set$ '
;' (
}) *
[ 	
Required	 
] 
public 
int 

CategoryId 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} î
eC:\Projects\Sendeo\Assestment\online-shop\ProductMicroservice\Business\Interfaces\ICategoryService.cs
	namespace 	
ProductMicroservice
 
. 
Business &
.& '

Interfaces' 1
{ 
public 

	interface 
ICategoryService %
{ 
int 
Create 
( 
CategoryDto 
categoryDto *
)* +
;+ ,
} 
}		 ú
dC:\Projects\Sendeo\Assestment\online-shop\ProductMicroservice\Business\Interfaces\IProductService.cs
	namespace 	
ProductMicroservice
 
. 
Business &
.& '

Interfaces' 1
{ 
public 

	interface 
IProductService $
{ 
int 
Create 
( 

ProductDto 

productDto (
)( )
;) *
IEnumerable 
< 

ProductDto 
> 
GetAll  &
(& '
)' (
;( )
}		 
}

 «	
dC:\Projects\Sendeo\Assestment\online-shop\ProductMicroservice\Business\Mappers\AutoMapperProfiles.cs
	namespace 	
ProductMicroservice
 
. 
Business &
.& '
Mappers' .
{ 
public 

class 
AutoMapperProfiles #
:$ %
Profile& -
{		 
public

 
AutoMapperProfiles

 !
(

! "
)

" #
{ 	
	CreateMap 
< 
Product 
, 

ProductDto )
>) *
(* +
)+ ,
., -

ReverseMap- 7
(7 8
)8 9
;9 :
	CreateMap 
< 
Category 
, 
CategoryDto  +
>+ ,
(, -
)- .
.. /

ReverseMap/ 9
(9 :
): ;
;; <
	CreateMap 
< 
Product 
, 
ProductCreateEvent 1
>1 2
(2 3
)3 4
.4 5

ReverseMap5 ?
(? @
)@ A
;A B
} 	
} 
} Ã
bC:\Projects\Sendeo\Assestment\online-shop\ProductMicroservice\Business\Services\CategoryService.cs
	namespace 	
ProductMicroservice
 
. 
Business &
.& '
Services' /
{		 
public

 

class

 
CategoryService

  
:

! "
ICategoryService

# 3
{ 
private 
readonly 
ICategoryRepository ,
_categoryRepository- @
;@ A
private 
readonly 
IMapper  
_mapper! (
;( )
public 
CategoryService 
( 
ICategoryRepository 2
categoryRepository3 E
,E F
IMapperG N
mapperO U
)U V
{ 	
_categoryRepository 
=  !
categoryRepository" 4
;4 5
_mapper 
= 
mapper 
; 
} 	
public 
int 
Create 
( 
CategoryDto %
categoryDto& 1
)1 2
{ 	
var 
categoryToCreate  
=! "
_mapper# *
.* +
Map+ .
<. /
CategoryDto/ :
,: ;
Category< D
>D E
(E F
categoryDtoF Q
)Q R
;R S
var 
category 
= 
_categoryRepository .
.. /
Create/ 5
(5 6
categoryToCreate6 F
)F G
;G H
_categoryRepository 
.  
Commit  &
(& '
)' (
;( )
return 
category 
. 
Id 
; 
} 	
} 
} Ö
aC:\Projects\Sendeo\Assestment\online-shop\ProductMicroservice\Business\Services\ProductService.cs
	namespace		 	
ProductMicroservice		
 
.		 
Business		 &
.		& '
Services		' /
{

 
public 

class 
ProductService 
:  !
IProductService" 1
{ 
private 
readonly 
IProductRepository +
_productRepository, >
;> ?
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IPublishEndpoint )
_publishEndpoint* :
;: ;
public 
ProductService 
( 
IProductRepository 0
productRepository1 B
,B C
IMapperD K
mapperL R
,R S
IPublishEndpointT d
publishEndpointe t
)t u
{ 	
_productRepository 
=  
productRepository! 2
;2 3
_mapper 
= 
mapper 
; 
_publishEndpoint 
= 
publishEndpoint .
;. /
} 	
public 
int 
Create 
( 

ProductDto $

productDto% /
)/ 0
{ 	
var 
productToCreate 
=  !
_mapper" )
.) *
Map* -
<- .

ProductDto. 8
,8 9
Product: A
>A B
(B C

productDtoC M
)M N
;N O
var 
product 
= 
_productRepository ,
., -
Create- 3
(3 4
productToCreate4 C
)C D
;D E
_productRepository 
. 
Commit %
(% &
)& '
;' (
var!! 
eventMessage!! 
=!! 
_mapper!! &
.!!& '
Map!!' *
<!!* +
Product!!+ 2
,!!2 3
ProductCreateEvent!!4 F
>!!F G
(!!G H
productToCreate!!H W
)!!W X
;!!X Y
_publishEndpoint"" 
."" 
Publish"" $
<""$ %
ProductCreateEvent""% 7
>""7 8
(""8 9
eventMessage""9 E
)""E F
;""F G
return$$ 
product$$ 
.$$ 
Id$$ 
;$$ 
}%% 	
public'' 
IEnumerable'' 
<'' 

ProductDto'' %
>''% &
GetAll''' -
(''- .
)''. /
{(( 	
var)) 
products)) 
=)) 
_productRepository)) -
.))- .
GetAll)). 4
())4 5
)))5 6
;))6 7
return** 
_mapper** 
.** 
Map** 
<** 
IEnumerable** *
<*** +
Product**+ 2
>**2 3
,**3 4
IEnumerable**5 @
<**@ A

ProductDto**A K
>**K L
>**L M
(**M N
products**N V
)**V W
;**W X
}++ 	
},, 
}-- Ø
_C:\Projects\Sendeo\Assestment\online-shop\ProductMicroservice\Controllers\CategoryController.cs
	namespace 	
ProductMicroservice
 
. 
Controllers )
{ 
[ 
Route 

(
 
$str 
) 
] 
[		 
ApiController		 
]		 
public

 

class

 
CategoryController

 #
:

$ %
ControllerBase

& 4
{ 
private 
readonly 
ICategoryService )
_categoryService* :
;: ;
public 
CategoryController !
(! "
ICategoryService" 2
categoryService3 B
)B C
{ 	
_categoryService 
= 
categoryService .
;. /
} 	
[ 	
HttpPost	 
] 
public 
ActionResult 
Create "
(" #
CategoryDto# .
categoryDto/ :
): ;
{ 	
var 

categoryId 
= 
_categoryService -
.- .
Create. 4
(4 5
categoryDto5 @
)@ A
;A B
return 
Ok 
( 
$" 
$str 1
{1 2

categoryId2 <
}< =
"= >
)> ?
;? @
} 	
} 
} 
^C:\Projects\Sendeo\Assestment\online-shop\ProductMicroservice\Controllers\ProductController.cs
	namespace 	
ProductMicroservice
 
. 
Controllers )
{ 
[ 
Route 

(
 
$str 
) 
] 
[		 
ApiController		 
]		 
public

 

class

 
ProductController

 "
:

# $
ControllerBase

% 3
{ 
private 
readonly 
IProductService (
_productService) 8
;8 9
public 
ProductController  
(  !
IProductService! 0
productService1 ?
)? @
{ 	
_productService 
= 
productService ,
;, -
} 	
[ 	
HttpPost	 
] 
public 
ActionResult 
Create "
(" #

ProductDto# -

productDto. 8
)8 9
{ 	
var 
	productId 
= 
_productService +
.+ ,
Create, 2
(2 3

productDto3 =
)= >
;> ?
return 
Ok 
( 
$" 
$str 0
{0 1
	productId1 :
}: ;
"; <
)< =
;= >
} 	
[ 	
HttpGet	 
] 
public 
ActionResult 
< 
List  
<  !

ProductDto! +
>+ ,
>, -
GetAll. 4
(4 5
)5 6
{ 	
return 
Ok 
( 
_productService %
.% &
GetAll& ,
(, -
)- .
). /
;/ 0
} 	
} 
}   ¬
]C:\Projects\Sendeo\Assestment\online-shop\ProductMicroservice\DataAccess\Entities\Category.cs
	namespace 	
ProductMicroservice
 
. 

DataAccess (
.( )
Entities) 1
{ 
public 

class 
Category 
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
[ 	
	MaxLength	 
( 
$num 
) 
] 
public		 
string		 
Description		 !
{		" #
get		$ '
;		' (
set		) ,
;		, -
}		. /
=		0 1
null		2 6
!		6 7
;		7 8
} 
} ­
\C:\Projects\Sendeo\Assestment\online-shop\ProductMicroservice\DataAccess\Entities\Product.cs
	namespace 	
ProductMicroservice
 
. 

DataAccess (
.( )
Entities) 1
{ 
public 

class 
Product 
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
[ 	
	MaxLength	 
( 
$num 
) 
] 
public		 
string		 
Name		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
=		) *
null		+ /
!		/ 0
;		0 1
[

 	
	MaxLength

	 
(

 
$num

 
)

 
]

 
public 
string 
? 
Description "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
decimal 
Price 
{ 
get "
;" #
set$ '
;' (
}) *
public 
Category 
Category  
{! "
get# &
;& '
set( +
;+ ,
}- .
=/ 0
null1 5
!5 6
;6 7
} 
} ‘

ZC:\Projects\Sendeo\Assestment\online-shop\ProductMicroservice\DataAccess\ProductContext.cs
	namespace 	
ProductMicroservice
 
. 

DataAccess (
{ 
public 

class 
ProductContext 
:  !
	DbContext" +
{ 
public		 
ProductContext		 
(		 
DbContextOptions		 .
<		. /
ProductContext		/ =
>		= >
options		? F
)		F G
:

 
base

 
(

 
options

 
)

 
{ 	
Database 
. 
EnsureCreated "
(" #
)# $
;$ %
} 	
public 
DbSet 
< 
Product 
> 
Products &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
=5 6
null7 ;
!; <
;< =
public 
DbSet 
< 
Category 
> 

Categories )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
=8 9
null: >
!> ?
;? @
} 
} ‚
kC:\Projects\Sendeo\Assestment\online-shop\ProductMicroservice\DataAccess\Repositories\CategoryRepository.cs
	namespace 	
ProductMicroservice
 
. 

DataAccess (
.( )
Repositories) 5
{ 
public 

class 
CategoryRepository #
:$ %
RepositoryBase& 4
<4 5
Product5 <
>< =
,= >
IProductRepository? Q
{ 
public 
CategoryRepository !
(! "
ProductContext" 0
productContext1 ?
)? @
:A B
baseC G
(G H
productContextH V
)V W
{		 	
}

 	
} 
} Ô
lC:\Projects\Sendeo\Assestment\online-shop\ProductMicroservice\DataAccess\Repositories\ICategoryRepository.cs
	namespace 	
ProductMicroservice
 
. 

DataAccess (
.( )
Repositories) 5
{ 
public 

	interface 
ICategoryRepository (
:) *
IRepository+ 6
<6 7
Category7 ?
>? @
{ 
} 
}		 Ñ
kC:\Projects\Sendeo\Assestment\online-shop\ProductMicroservice\DataAccess\Repositories\IProductRepository.cs
	namespace 	
ProductMicroservice
 
. 

DataAccess (
.( )
Repositories) 5
{ 
public 

	interface 
IProductRepository '
:( )
IRepository* 5
<5 6
Product6 =
>= >
{ 
}		 
}

 ÿ
jC:\Projects\Sendeo\Assestment\online-shop\ProductMicroservice\DataAccess\Repositories\ProductRepository.cs
	namespace 	
ProductMicroservice
 
. 

DataAccess (
.( )
Repositories) 5
{ 
public 

class 
ProductRepository "
:# $
RepositoryBase% 3
<3 4
Product4 ;
>; <
,< =
IProductRepository> P
{ 
public 
ProductRepository  
(  !
ProductContext! /
productContext0 >
)> ?
:@ A
baseB F
(F G
productContextG U
)U V
{		 	
}

 	
} 
} Ë
HC:\Projects\Sendeo\Assestment\online-shop\ProductMicroservice\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
builder 
. 
Services 
. 
AddSwaggerGen 
( 
)  
;  !
var 
dbConnectionString 
= 
builder  
.  !
Configuration! .
.. /

GetSection/ 9
(9 :
$str: g
)g h
.h i
Valuei n
;n o
builder 
. 
Services 
. 
	AddSqlite 
< 
ProductContext )
>) *
(* +
dbConnectionString+ =
)= >
;> ?
builder 
. 
Services 
. 
AddAutoMapper 
( 
typeof %
(% &
Program& -
)- .
.. /
Assembly/ 7
)7 8
;8 9
builder 
. 
Services 
. 
	AddScoped 
< 
IProductService *
,* +
ProductService, :
>: ;
(; <
)< =
;= >
builder 
. 
Services 
. 
	AddScoped 
< 
IProductRepository -
,- .
ProductRepository/ @
>@ A
(A B
)B C
;C D
builder 
. 
Services 
. 
AddMassTransit 
(  
config  &
=>' )
{* +
config 

.
 
UsingRabbitMq 
( 
( 
ctx 
, 
cfg "
)" #
=>$ &
{' (
cfg 
. 
Host 
( 
builder 
. 
Configuration &
[& '
$str' E
]E F
)F G
;G H
} 
) 
; 
} 
) 
; 
var"" 
app"" 
="" 	
builder""
 
."" 
Build"" 
("" 
)"" 
;"" 
if%% 
(%% 
app%% 
.%% 
Environment%% 
.%% 
IsDevelopment%% !
(%%! "
)%%" #
)%%# $
{&& 
app'' 
.'' 

UseSwagger'' 
('' 
)'' 
;'' 
app(( 
.(( 
UseSwaggerUI(( 
((( 
)(( 
;(( 
})) 
app++ 
.++ 
UseHttpsRedirection++ 
(++ 
)++ 
;++ 
app-- 
.-- 
UseAuthorization-- 
(-- 
)-- 
;-- 
app// 
.// 
MapControllers// 
(// 
)// 
;// 
app11 
.11 
Run11 
(11 
)11 	
;11	 
