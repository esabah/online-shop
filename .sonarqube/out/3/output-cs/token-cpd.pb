£
yC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\Business\Commands\CreateCustomerView\CreateCustomerCommand.cs
	namespace 	
OrderMicroservice
 
. 
Business $
.$ %
Commands% -
.- .
CreateCustomer. <
{ 
public 

class !
CreateCustomerCommand &
:' (
CustomerView) 5
,5 6
IRequest7 ?
<? @
int@ C
>C D
{ 
}

 
} ä
ÄC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\Business\Commands\CreateCustomerView\CreateCustomerCommandHandler.cs
	namespace 	
OrderMicroservice
 
. 
Business $
.$ %
Commands% -
.- .
CreateCustomer. <
{ 
public 

class (
CreateCustomerCommandHandler -
:. /
IRequestHandler0 ?
<? @!
CreateCustomerCommand@ U
,U V
intW Z
>Z [
{		 
private

 
readonly

 #
ICustomerViewRepository

 0#
_customerViewRepository

1 H
;

H I
public (
CreateCustomerCommandHandler +
(+ ,#
ICustomerViewRepository, C"
customerViewRepositoryD Z
,Z [
IMapper\ c
mapperd j
)j k
{ 	#
_customerViewRepository #
=$ %"
customerViewRepository& <
;< =
} 	
public 
async 
Task 
< 
int 
> 
Handle %
(% &!
CreateCustomerCommand& ;
request< C
,C D
CancellationTokenE V
cancellationTokenW h
)h i
{ 	
var 
newOrder 
= #
_customerViewRepository 2
.2 3
Create3 9
(9 :
request: A
)A B
;B C
await #
_customerViewRepository )
.) *
CommitAsync* 5
(5 6
)6 7
;7 8
return 
newOrder 
. 
Id 
; 
} 	
} 
} †
wC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\Business\Commands\CreateOrderView\CreateOrderViewCommand.cs
	namespace 	
OrderMicroservice
 
. 
Business $
.$ %
Commands% -
.- .
CreateOrderView. =
{ 
public 

class "
CreateOrderViewCommand '
:( )
	OrderView* 3
,4 5
IRequest6 >
<> ?
int? B
>B C
{ 
}		 
}

 ¬
~C:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\Business\Commands\CreateOrderView\CreateOrderViewCommandHandler.cs
	namespace 	
OrderMicroservice
 
. 
Business $
.$ %
Commands% -
.- .
CreateORderView. =
{ 
public		 

class		 )
CreateOrderViewCommandHandler		 .
:		0 1
IRequestHandler		3 B
<		B C"
CreateOrderViewCommand		C Y
,		Y Z
int		[ ^
>		^ _
{

 
private 
readonly  
IOrderViewRepository -!
_orderQueryRepository. C
;C D
public )
CreateOrderViewCommandHandler ,
(, - 
IOrderViewRepository- A 
orderQueryRepositoryB V
)V W
{ 	!
_orderQueryRepository !
=" # 
orderQueryRepository$ 8
;8 9
} 	
public 
async 
Task 
< 
int 
> 
Handle %
(% &"
CreateOrderViewCommand& <
request= D
,D E
CancellationTokenF W
cancellationTokenX i
)i j
{ 	
var 
newOrder 
= !
_orderQueryRepository 0
.0 1
Create1 7
(7 8
request8 ?
)? @
;@ A
await !
_orderQueryRepository '
.' (
CommitAsync( 3
(3 4
)4 5
;5 6
return 
newOrder 
. 
Id 
; 
} 	
} 
} ÷	
oC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\Business\Commands\CreateOrder\CreateOrderCommand.cs
	namespace 	
OrderMicroservice
 
. 
Business $
.$ %
Commands% -
.- .
CreateOrder. 9
{ 
public 

class 
CreateOrderCommand #
:$ %
IRequest& .
<. /
int/ 2
>2 3
{ 
public 
int 

CustomerId 
{ 
get  #
;# $
set% (
;( )
}* +
public		 
string		 
?		 
BillingAddress		 %
{		& '
get		( +
;		+ ,
set		- 0
;		0 1
}		2 3
public

 
string

 
?

 
ShippingAddress

 &
{

' (
get

) ,
;

, -
set

. 1
;

1 2
}

3 4
public 
ICollection 
< 
OrderDetailDto )
>) *
?* +
OrderDetails, 8
{9 :
get; >
;> ?
set@ C
;C D
}E F
} 
} ÿG
vC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\Business\Commands\CreateOrder\CreateOrderCommandHandler.cs
	namespace

 	
OrderMicroservice


 
.

 
Business

 $
.

$ %
Commands

% -
.

- .
CreateOrder

. 9
{ 
public 

class %
CreateOrderCommandHandler *
:+ ,
IRequestHandler- <
<< =
CreateOrderCommand= O
,O P
intQ T
>T U
{ 
private 
readonly 
IOrderRepository )
_orderRepository* :
;: ;
private 
readonly #
ICustomerViewRepository 0#
_customerViewRepository1 H
;H I
private 
readonly "
IProductViewRepository /"
_productViewRepository0 F
;F G
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IPublishEndpoint )
_publishEndpoint* :
;: ;
public %
CreateOrderCommandHandler (
(( )
IOrderRepository) 9
orderRepository: I
,I J#
ICustomerViewRepositoryK b"
customerViewRepositoryc y
,y z#
IProductViewRepository	{ ë#
productViewRepository
í ß
,
ß ®
IMapper
© ∞
mapper
± ∑
,
∑ ∏
IPublishEndpoint
π …
publishEndpoint
  Ÿ
)
Ÿ ⁄
{ 	
_orderRepository 
= 
orderRepository .
;. /#
_customerViewRepository #
=$ %"
customerViewRepository& <
;< ="
_productViewRepository "
=# $!
productViewRepository% :
;: ;
_mapper 
= 
mapper 
; 
_publishEndpoint 
= 
publishEndpoint .
;. /
} 	
public 
async 
Task 
< 
int 
> 
Handle %
(% &
CreateOrderCommand& 8
request9 @
,@ A
CancellationTokenB S
cancellationTokenT e
)e f
{ 	
var 
orderEntity 
= 
_mapper %
.% &
Map& )
<) *
CreateOrderCommand* <
,< =
Order> C
>C D
(D E
requestE L
)L M
;M N
if!! 
(!! 
request!! 
.!! 
OrderDetails!! #
!=!!$ &
null!!' +
)!!+ ,
orderEntity"" 
."" 
OrderDetails"" '
=""( )
_mapper""* 1
.""1 2
Map""2 5
<""5 6
ICollection""6 A
<""A B
OrderDetailDto""B P
>""P Q
,""Q R
ICollection""S ^
<""^ _
OrderDetail""_ j
>""j k
>""k l
(""l m
request""m t
.""t u
OrderDetails	""u Å
)
""Å Ç
;
""Ç É
var$$ 
customerDetail$$ 
=$$  #
_customerViewRepository$$! 8
.$$8 9
GetById$$9 @
($$@ A
orderEntity$$A L
.$$L M

CustomerId$$M W
)$$W X
;$$X Y
ValidateConsistency%% 
(%%  
customerDetail%%  .
,%%. /
orderEntity%%0 ;
)%%; <
;%%< =
orderEntity'' 
.'' 
Status'' 
=''  
$str''! *
;''* +
var(( 
newOrder(( 
=(( 
_orderRepository(( ,
.((, -
Create((- 3
(((3 4
orderEntity((4 ?
)((? @
;((@ A
await)) 
_orderRepository)) "
.))" #
CommitAsync))# .
()). /
)))/ 0
;))0 1
await-- 
_publishEndpoint-- !
.--! "
Publish--" )
<--) *
OrderCreateEvent--* :
>--: ;
(--; <
BuildMessage--< H
(--H I
customerDetail--I W
,--X Y
newOrder--Z b
)--b c
,--c d
new--d g
CancellationToken--h y
(--y z
)--z {
)--{ |
;--| }
return// 
newOrder// 
.// 
Id// 
;// 
}00 	
private22 
OrderCreateEvent22  
BuildMessage22! -
(22- .
CustomerView22. :
customerDetail22; I
,22I J
Order22J O
order22P U
)22U V
{33 	
OrderCreateEvent44 
orderCreateEvent44 -
=44. /
_mapper440 7
.447 8
Map448 ;
<44; <
Order44< A
,44A B
OrderCreateEvent44C S
>44S T
(44T U
order44U Z
)44Z [
;44[ \
orderCreateEvent55 
=55 
_mapper55 %
.55% &
Map55& )
<55) *
CustomerView55* 6
,556 7
OrderCreateEvent558 H
>55H I
(55I J
customerDetail55J X
,55X Y
orderCreateEvent55Z j
)55j k
;55k l
if77 
(77 
orderCreateEvent77  
.77  !
OrderDetails77! -
!=77. 0
null771 5
&&776 8
order779 >
.77> ?
OrderDetails77? K
!=77L N
null77O S
)77S T
{88 
var99 
productsInOrder99 #
=99$ %"
_productViewRepository99& <
.99< =
GetByIdList99= H
(99H I
order99I N
.99N O
OrderDetails99O [
.99[ \
Select99\ b
(99b c
x99c d
=>99e g
x99h i
.99i j
	ProductId99j s
)99s t
.99t u
ToArray99u |
(99| }
)99} ~
)99~ 
;	99 Ä
orderCreateEvent::  
.::  !
OrderDetails::! -
.::- .
ToList::. 4
(::4 5
)::5 6
.::6 7
ForEach::7 >
(::> ?
x::? @
=>::A C
x::D E
.::E F
ProductName::F Q
=::R S
productsInOrder::T c
.::c d
FirstOrDefault::d r
(::r s
y::s t
=>::u w
y::x y
.::y z
Id::z |
==::} 
x
::Ä Å
.
::Å Ç
	ProductId
::Ç ã
)
::ã å
?
::å ç
.
::ç é
Name
::é í
??
::ì ï
$str
::ñ ò
)
::ò ô
;
::ô ö
};; 
return== 
orderCreateEvent== #
;==# $
}>> 	
private@@ 
void@@ 
ValidateConsistency@@ (
(@@( )
CustomerView@@) 5
customerDetail@@6 D
,@@D E
Order@@F K
orderEntity@@L W
)@@W X
{AA 	
ifBB 
(BB 
customerDetailBB 
==BB !
nullBB" &
)BB& '
{CC 
throwDD 
newDD 
ArgumentExceptionDD +
(DD+ ,
$"DD, .
$strDD. ?
{DD? @
orderEntityDD@ K
.DDK L

CustomerIdDDL V
}DDV W
$strDDW b
"DDb c
)DDc d
;DDd e
}EE 
ifHH 
(HH 
orderEntityHH 
.HH 
OrderDetailsHH (
!=HH) +
nullHH, 0
)HH0 1
{II 
varJJ 
productsInOrderJJ #
=JJ$ %"
_productViewRepositoryJJ& <
.JJ< =
GetByIdListJJ= H
(JJH I
orderEntityJJI T
.JJT U
OrderDetailsJJU a
.JJa b
SelectJJb h
(JJh i
xJJi j
=>JJk m
xJJn o
.JJo p
	ProductIdJJp y
)JJy z
.JJz {
ToArray	JJ{ Ç
(
JJÇ É
)
JJÉ Ñ
)
JJÑ Ö
.
JJÖ Ü
ToList
JJÜ å
(
JJå ç
)
JJç é
;
JJé è
foreachLL 
(LL 
varLL 
itemLL !
inLL" $
orderEntityLL% 0
.LL0 1
OrderDetailsLL1 =
.LL= >
SelectLL> D
(LLD E
xLLE F
=>LLG I
xLLJ K
.LLK L
	ProductIdLLL U
)LLU V
)LLV W
{MM 
ifNN 
(NN 
!NN 
productsInOrderNN (
.NN( )
AnyNN) ,
(NN, -
xNN- .
=>NN/ 1
xNN2 3
.NN3 4
IdNN4 6
==NN7 9
itemNN: >
)NN> ?
)NN? @
{OO 
throwPP 
newPP !
ArgumentExceptionPP" 3
(PP3 4
$"PP4 6
$strPP6 F
{PPF G
itemPPG K
}PPK L
$strPPL W
"PPW X
)PPX Y
;PPY Z
}QQ 
}RR 
}SS 
}TT 	
}WW 
}XX û
wC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\Business\Commands\CreateProductView\CreateProductCommand.cs
	namespace 	
OrderMicroservice
 
. 
Business $
.$ %
Commands% -
.- .
CreateProduct. ;
{ 
public 

class  
CreateProductCommand %
:& '
ProductView( 3
,4 5
IRequest6 >
<> ?
int? B
>B C
{ 
}		 
}

 ¬
~C:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\Business\Commands\CreateProductView\CreateProductCommandHandler.cs
	namespace 	
OrderMicroservice
 
. 
Business $
.$ %
Commands% -
.- .
CreateProduct. ;
{ 
public 

class '
CreateProductCommandHandler ,
:. /
IRequestHandler1 @
<@ A 
CreateProductCommandA U
,U V
intW Z
>Z [
{		 
private

 
readonly

 "
IProductViewRepository

 /"
_productViewRepository

0 F
;

F G
public '
CreateProductCommandHandler *
(* +"
IProductViewRepository+ A!
productViewRepositoryB W
)W X
{ 	"
_productViewRepository "
=# $!
productViewRepository% :
;: ;
} 	
public 
async 
Task 
< 
int 
> 
Handle %
(% & 
CreateProductCommand& :
request; B
,B C
CancellationTokenD U
cancellationTokenV g
)g h
{ 	
var 
newOrder 
= "
_productViewRepository 1
.1 2
Create2 8
(8 9
request9 @
)@ A
;A B
await "
_productViewRepository (
.( )
CommitAsync) 4
(4 5
)5 6
;6 7
return 
newOrder 
. 
Id 
; 
} 	
} 
} ü
[C:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\Business\Dtos\OrderDetailDto.cs
	namespace 	
OrderMicroservice
 
. 
Business $
.$ %
Dtos% )
{ 
public 

class 
OrderDetailDto 
{ 
public 
int 
	ProductId 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 
Quantity 
{ 
get !
;! "
set# &
;& '
}( )
public 
decimal 
Price 
{ 
get "
;" #
set$ '
;' (
}) *
}		 
}

 Ê
bC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\Business\Mappers\AutoMapperProfiles.cs
	namespace

 	
OrderMicroservice


 
.

 
Business

 $
.

$ %
Mappers

% ,
{ 
public 

class 
AutoMapperProfiles #
:$ %
Profile& -
{ 
public 
AutoMapperProfiles !
(! "
)" #
{ 	
	CreateMap 
< 
Order 
, 
CreateOrderCommand /
>/ 0
(0 1
)1 2
.2 3

ReverseMap3 =
(= >
)> ?
;? @
	CreateMap 
< 
OrderDetail !
,! "
OrderDetailDto# 1
>1 2
(2 3
)3 4
.4 5

ReverseMap5 ?
(? @
)@ A
;A B
	CreateMap 
< 
Order 
, 
OrderCreateEvent -
>- .
(. /
)/ 0
.0 1

ReverseMap1 ;
(; <
)< =
;= >
	CreateMap 
< 
CustomerView "
," #
OrderCreateEvent$ 4
>4 5
(5 6
)6 7
. 
	ForMember 
( 
d 
=> 
d 
. 
CustomerEmail *
,* +
o, -
=>. 0
o1 2
.2 3
MapFrom3 :
(: ;
s; <
=>= ?
s@ A
.A B
EmailB G
)G H
)H I
. 
	ForMember 
( 
d 
=> 
d 
. 
CustomerName )
,) *
o+ ,
=>- /
o0 1
.1 2
MapFrom2 9
(9 :
s: ;
=>< >
s? @
.@ A
NameA E
)E F
)F G
. 
	ForMember 
( 
d 
=> 
d 
. 
CustomerSurName ,
,, -
o. /
=>0 2
o3 4
.4 5
MapFrom5 <
(< =
s= >
=>? A
sB C
.C D
SurnameD K
)K L
)L M
. 
	ForMember 
( 
d 
=> 
d 
. 
CustomerPhoneNumber 0
,0 1
o2 3
=>4 6
o7 8
.8 9
MapFrom9 @
(@ A
sA B
=>C E
sF G
.G H
PhoneNumberH S
)S T
)T U
;U V
	CreateMap 
< 
OrderDetail !
,! ""
OrderDetailCreateEvent# 9
>9 :
(: ;
); <
.< =

ReverseMap= G
(G H
)H I
;I J
	CreateMap 
< !
CreateCustomerCommand +
,+ ,
CustomerCreateEvent- @
>@ A
(A B
)B C
.C D

ReverseMapD N
(N O
)O P
;P Q
	CreateMap 
<  
CreateProductCommand *
,* +
ProductCreateEvent, >
>> ?
(? @
)@ A
.A B

ReverseMapB L
(L M
)M N
;N O
	CreateMap 
< "
CreateOrderViewCommand ,
,, -
OrderCreateEvent. >
>> ?
(? @
)@ A
.A B

ReverseMapB L
(L M
)M N
;N O
	CreateMap   
<   
OrderDetailView   %
,  % &"
OrderDetailCreateEvent  ' =
>  = >
(  > ?
)  ? @
.  @ A

ReverseMap  A K
(  K L
)  L M
;  M N
}%% 	
}&& 
}'' œ
lC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\Business\Queries\QueryOrders\GetOrdersHandler.cs
	namespace 	
OrderMicroservice
 
. 
Business $
.$ %
Queries% ,
., -
QueryOrders- 8
{ 
public 

class 
GetOrdersHandler !
:" #
IRequestHandler$ 3
<3 4
GetOrdersQuery4 B
,B C
ListD H
<H I
	OrderViewI R
>R S
>S T
{		 
private

 
readonly

  
IOrderViewRepository

 -!
_orderQueryRepository

. C
;

C D
public 
GetOrdersHandler 
(   
IOrderViewRepository  4 
orderQueryRepository5 I
)I J
{ 	!
_orderQueryRepository !
=" # 
orderQueryRepository$ 8
;8 9
} 	
public 
async 
Task 
< 
List 
< 
	OrderView (
>( )
>) *
Handle+ 1
(1 2
GetOrdersQuery2 @
requestA H
,H I
CancellationTokenJ [
cancellationToken\ m
)m n
{ 	
var 
	orderList 
= 
await !!
_orderQueryRepository" 7
.7 8
GetOrdersByDate8 G
(G H
requestH O
.O P
	StartDateP Y
,Y Z
requestZ a
.a b
EndDateb i
)i j
;j k
return 
	orderList 
; 
} 	
} 
} π	
jC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\Business\Queries\QueryOrders\GetOrdersQuery.cs
	namespace 	
OrderMicroservice
 
. 
Business $
.$ %
Queries% ,
., -
QueryOrders- 8
{ 
public 

class 
GetOrdersQuery 
:  
IRequest" *
<* +
List+ /
</ 0
	OrderView0 9
>9 :
>: ;
{ 
public 
GetOrdersQuery 
( 
DateTime &
	startDate' 0
,0 1
DateTime2 :
endDate; B
)B C
{		 	
	StartDate

 
=

 
	startDate

 !
;

! "
EndDate 
= 
endDate 
; 
} 	
public 
DateTime 
	StartDate !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
DateTime 
EndDate 
{  !
get" %
;% &
set' *
;* +
}, -
} 
} µ
ZC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\Controllers\OrderController.cs
	namespace 	
OrderMicroservice
 
. 
Controllers '
{		 
[

 
Route

 

(


 
$str

 
)

 
]

 
[ 
ApiController 
] 
public 

class 
OrderController  
:! "
ControllerBase# 1
{ 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
public 
OrderController 
( 
	IMediator (
mediator) 1
)1 2
{ 	
	_mediator 
= 
mediator  
;  !
} 	
[ 	
HttpPost	 
] 
public 
async 
Task 
< 
ActionResult &
<& '
int' *
>* +
>+ ,
Create- 3
(3 4
[4 5
FromBody5 =
]= >
CreateOrderCommand? Q
commandR Y
)Y Z
{ 	
var 
result 
= 
await 
	_mediator (
.( )
Send) -
(- .
command. 5
)5 6
;6 7
return 
Ok 
( 
result 
) 
; 
} 	
[ 	
HttpGet	 
] 
public 
async 
Task 
< 
ActionResult &
<& '
IEnumerable' 2
<2 3
	OrderView3 <
>< =
>= >
>> ?
GetOrdersByDate@ O
(O P
DateTimeP X
	startDateY b
,b c
DateTimed l
endDatem t
)t u
{ 	
var 
query 
= 
new 
GetOrdersQuery *
(* +
	startDate+ 4
,4 5
endDate6 =
)= >
;> ?
var   
orders   
=   
await   
	_mediator   (
.  ( )
Send  ) -
(  - .
query  . 3
)  3 4
;  4 5
return!! 
Ok!! 
(!! 
orders!! 
)!! 
;!! 
}"" 	
}## 
}$$ Ï
fC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\DataAccess\Entities\OrderEntities\Order.cs
	namespace 	
OrderMicroservice
 
. 

DataAccess &
.& '
Entities' /
{ 
public 

class 
Order 
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
int 

CustomerId 
{ 
get  #
;# $
set% (
;( )
}* +
public		 
string		 
Status		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
=		+ ,
null		- 1
!		1 2
;		2 3
public

 
DateTime

 
	OrderDate

 !
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
0 1
DateTime

2 :
.

: ;
Now

; >
;

> ?
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
? 
BillingAddress %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
? 
ShippingAddress &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
ICollection 
< 
OrderDetail &
>& '
?' (
OrderDetails) 5
{6 7
get8 ;
;; <
set= @
;@ A
}B C
} 
} ﬁ
lC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\DataAccess\Entities\OrderEntities\OrderDetail.cs
	namespace 	
OrderMicroservice
 
. 

DataAccess &
.& '
Entities' /
{ 
public 

class 
OrderDetail 
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
int 
OrderId 
{ 
get  
;  !
set" %
;% &
}' (
public 
int 
	ProductId 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 
Quantity 
{ 
get !
;! "
set# &
;& '
}( )
public		 
decimal		 
Price		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
}

 
} §
lC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\DataAccess\Entities\ViewEntities\CustomerView.cs
	namespace 	
OrderMicroservice
 
. 

DataAccess &
.& '
Entities' /
{ 
public 

class 
CustomerView 
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
 
)

 
]

 
public 
string 
Surname 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
null. 2
!2 3
;3 4
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
? 
Email 
{ 
get "
;" #
set$ '
;' (
}) *
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
? 
PhoneNumber "
{# $
get% (
;( )
set* -
;- .
}/ 0
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
? 
Address 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} ®
oC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\DataAccess\Entities\ViewEntities\OrderDetailView.cs
	namespace 	
OrderMicroservice
 
. 

DataAccess &
.& '
Entities' /
{ 
public 

class 
OrderDetailView  
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
int 
OrderId 
{ 
get  
;  !
set" %
;% &
}' (
public		 
int		 
	ProductId		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
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
 
)

 
]

 
public 
string 
ProductName !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
null2 6
!6 7
;7 8
public 
int 
Quantity 
{ 
get !
;! "
set# &
;& '
}( )
public 
decimal 
Price 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} Í
iC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\DataAccess\Entities\ViewEntities\OrderView.cs
	namespace 	
OrderMicroservice
 
. 

DataAccess &
.& '
Entities' /
{ 
public 

class 
	OrderView 
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
DateTime 
	OrderDate !
{" #
get$ '
;' (
set) ,
;, -
}. /
[		 	
	MaxLength			 
(		 
$num		 
)		 
]		 
public

 
string

 
CustomerName

 "
{

# $
get

% (
;

( )
set

* -
;

- .
}

/ 0
=

1 2
null

3 7
!

7 8
;

8 9
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
CustomerSurName %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
=4 5
null6 :
!: ;
;; <
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
? 
CustomerEmail $
{% &
get' *
;* +
set, /
;/ 0
}1 2
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
? 
CustomerPhoneNumber *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
? 
BillingAddress %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
? 
ShippingAddress &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
IEnumerable 
< 
OrderDetailView *
>* +
?+ ,
OrderDetails- 9
{: ;
get< ?
;? @
setA D
;D E
}F G
} 
} Œ
kC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\DataAccess\Entities\ViewEntities\ProductView.cs
	namespace 	
OrderMicroservice
 
. 

DataAccess &
.& '
Entities' /
{ 
public 

class 
ProductView 
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
;		0 1
public

 
decimal

 
Price

 
{

 
get

 "
;

" #
set

$ '
;

' (
}

) *
} 
} ç
]C:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\DataAccess\OrderCommandContext.cs
	namespace 	
OrderMicroservice
 
. 

DataAccess &
{ 
public 

class 
OrderCommandContext $
:% &
	DbContext' 0
{ 
public 
OrderCommandContext "
(" #
DbContextOptions# 3
<3 4
OrderCommandContext4 G
>G H
optionsI P
)P Q
:		 
base			 
(		 
options		 
)		 
{

 	
Database 
. 
EnsureCreated "
(" #
)# $
;$ %
} 	
public 
DbSet 
< 
Order 
> 
Orders "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
null3 7
!7 8
;8 9
} 
} Ÿ
yC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\DataAccess\Repositories\OrderRepositories\IOrderRepository.cs
	namespace 	
OrderMicroservice
 
. 

DataAccess &
.& '
Repositories' 3
{ 
public 

	interface 
IOrderRepository %
:& '
IRepository( 3
<3 4
Order4 9
>9 :
{ 
}		 
}

 í
xC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\DataAccess\Repositories\OrderRepositories\OrderRepository.cs
	namespace 	
OrderMicroservice
 
. 

DataAccess &
.& '
Repositories' 3
{ 
public 

class 
OrderRepository  
:! "
RepositoryBase# 1
<1 2
Order2 7
>7 8
,8 9
IOrderRepository: J
{ 
public 
OrderRepository 
( 
OrderCommandContext 2
orderCommandContext3 F
)F G
:H I
baseJ N
(N O
orderCommandContextO b
)b c
{		 	
}

 	
} 
} û
~C:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\DataAccess\Repositories\ViewRepositories\CustomerViewRepository.cs
	namespace 	
OrderMicroservice
 
. 

DataAccess &
.& '
Repositories' 3
{ 
public 

class "
CustomerViewRepository '
:' (
RepositoryBase) 7
<7 8
CustomerView8 D
>D E
,F G#
ICustomerViewRepositoryH _
{ 
public "
CustomerViewRepository %
(% &
ViewContext& 1
queryContext2 >
)> ?
:@ A
baseB F
(F G
queryContextG S
)S T
{		 	
}

 	
} 
} Ì
C:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\DataAccess\Repositories\ViewRepositories\ICustomerViewRepository.cs
	namespace 	
OrderMicroservice
 
. 

DataAccess &
.& '
Repositories' 3
{ 
public 

	interface #
ICustomerViewRepository ,
:- .
IRepository/ :
<: ;
CustomerView; G
>G H
{ 
} 
}		 å
|C:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\DataAccess\Repositories\ViewRepositories\IOrderViewRepository.cs
	namespace 	
OrderMicroservice
 
. 

DataAccess &
.& '
Repositories' 3
{ 
public 

	interface  
IOrderViewRepository )
:* +
IRepository, 7
<7 8
	OrderView8 A
>A B
{ 
Task 
< 
List 
< 
	OrderView 
> 
> 
GetOrdersByDate -
(- .
DateTime. 6
	startDate7 @
,@ A
DateTimeB J
endDateK R
)R S
;S T
}		 
}

 ¿
~C:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\DataAccess\Repositories\ViewRepositories\IProductViewRepository.cs
	namespace 	
OrderMicroservice
 
. 

DataAccess &
.& '
Repositories' 3
{ 
public 

	interface "
IProductViewRepository +
:, -
IRepository. 9
<9 :
ProductView: E
>E F
{ 
IEnumerable 
< 
ProductView 
>  
GetByIdList! ,
(, -
int- 0
[0 1
]1 2
ids3 6
)6 7
;7 8
}		 
}

 €
{C:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\DataAccess\Repositories\ViewRepositories\OrderViewRepository.cs
	namespace 	
OrderMicroservice
 
. 

DataAccess &
.& '
Repositories' 3
{ 
public 

class 
OrderViewRepository $
:% &
RepositoryBase' 5
<5 6
	OrderView6 ?
>? @
,@ A 
IOrderViewRepositoryB V
{ 
	protected		 
readonly		 
ViewContext		 &
_orderQueryContext		' 9
;		9 :
public 
OrderViewRepository "
(" #
ViewContext# .
orderQueryContext/ @
)@ A
:B C
baseD H
(H I
orderQueryContextI Z
)Z [
{ 	
_orderQueryContext 
=  
orderQueryContext! 2
;2 3
} 	
public 
async 
Task 
< 
List 
< 
	OrderView (
>( )
>) *
GetOrdersByDate+ :
(: ;
DateTime; C
	startDateD M
,M N
DateTimeO W
endDateX _
)_ `
{ 	
return 
await 
_orderQueryContext +
.+ ,

OrderViews, 6
.6 7
Where7 <
(< =
x= >
=>> @
xA B
.B C
	OrderDateC L
>=L N
	startDateO X
&&Y [
x\ ]
.] ^
	OrderDate^ g
<=g i
endDatej q
)q r
.r s
Includes z
(z {
y{ |
=>| ~
y	 Ä
.
Ä Å
OrderDetails
Å ç
)
ç é
.
é è
ToListAsync
è ö
(
ö õ
)
õ ú
;
ú ù
} 	
} 
} ‹
}C:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\DataAccess\Repositories\ViewRepositories\ProductViewRepository.cs
	namespace 	
OrderMicroservice
 
. 

DataAccess &
.& '
Repositories' 3
{ 
public 

class !
ProductViewRepository &
:' (
RepositoryBase) 7
<7 8
ProductView8 C
>C D
,D E"
IProductViewRepositoryF \
{ 
private		 
readonly		 
ViewContext		 $
_queryContext		% 2
;		2 3
public

 !
ProductViewRepository

 $
(

$ %
ViewContext

% 0
queryContext

1 =
)

= >
:

? @
base

A E
(

E F
queryContext

F R
)

R S
{ 	
_queryContext 
= 
queryContext (
;( )
} 	
public 
IEnumerable 
< 
ProductView &
>& '
GetByIdList( 3
(3 4
int4 7
[7 8
]8 9
ids: =
)= >
{ 	
return 
_queryContext  
.  !
ProductViews! -
.- .
Where. 3
(3 4
x4 5
=>6 8
ids9 <
.< =
Contains= E
(E F
xF G
.G H
IdH J
)J K
)K L
.L M
ToListM S
(S T
)T U
;U V
} 	
} 
} °
UC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\DataAccess\ViewContext.cs
	namespace 	
OrderMicroservice
 
. 

DataAccess &
{ 
public 

class 
ViewContext 
: 
	DbContext (
{ 
public 
ViewContext 
( 
DbContextOptions +
<+ ,
ViewContext, 7
>7 8
options9 @
)@ A
:		 
base		 
(		 
options		 
)		 
{

 	
Database 
. 
EnsureCreated "
(" #
)# $
;$ %
} 	
public 
DbSet 
< 
	OrderView 
> 

OrderViews  *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
=9 :
null; ?
!? @
;@ A
public 
DbSet 
< 
ProductView  
>  !
ProductViews" .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
== >
null? C
!C D
;D E
public 
DbSet 
< 
CustomerView !
>! "
CustomerViews# 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
=? @
nullA E
!E F
;F G
} 
} ã
hC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\EventConsumer\CustomerCreateEventConsumer.cs
	namespace 	
OrderMicroservice
 
. 
MessageConsumer +
{		 
public

 

class

 '
CustomerCreateEventConsumer

 ,
:

- .
	IConsumer

/ 8
<

8 9
CustomerCreateEvent

9 L
>

L M
{ 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
private 
readonly 
IMapper  
_mapper! (
;( )
public '
CustomerCreateEventConsumer *
(* +
	IMediator+ 4
mediator5 =
,= >
IMapper? F
mapperG M
)M N
{ 	
	_mediator 
= 
mediator  
;  !
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
Consume !
(! "
ConsumeContext" 0
<0 1
CustomerCreateEvent1 D
>D E
contextF M
)M N
{ 	
var 
command 
= 
_mapper !
.! "
Map" %
<% &!
CreateCustomerCommand& ;
>; <
(< =
context= D
.D E
MessageE L
)L M
;M N
await 
	_mediator 
. 
Send  
(  !
command! (
)( )
;) *
} 	
} 
} â
iC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\EventConsumer\OrderViewCreateEventConsumer.cs
	namespace		 	
OrderMicroservice		
 
.		 
MessageConsumer		 +
{

 
public 

class (
OrderViewCreateEventConsumer -
:. /
	IConsumer0 9
<9 :
OrderCreateEvent: J
>J K
{ 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
private 
readonly 
IMapper  
_mapper! (
;( )
public (
OrderViewCreateEventConsumer +
(+ ,
	IMediator, 5
mediator6 >
,> ?
IMapper@ G
mapperH N
)N O
{ 	
	_mediator 
= 
mediator  
;  !
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
Consume !
(! "
ConsumeContext" 0
<0 1
OrderCreateEvent1 A
>A B
contextC J
)J K
{ 	
var 
command 
= 
_mapper !
.! "
Map" %
<% &"
CreateOrderViewCommand& <
>< =
(= >
context> E
.E F
MessageF M
)M N
;N O
await 
	_mediator 
. 
Send  
(  !
command! (
)( )
;) *
} 	
} 
} Ö
gC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\EventConsumer\ProductCreateEventConsumer.cs
	namespace		 	
OrderMicroservice		
 
.		 
MessageConsumer		 +
{

 
public 

class &
ProductCreateEventConsumer +
:, -
	IConsumer. 7
<7 8
ProductCreateEvent8 J
>J K
{ 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
private 
readonly 
IMapper  
_mapper! (
;( )
public &
ProductCreateEventConsumer )
() *
	IMediator* 3
mediator4 <
,< =
IMapper> E
mapperF L
)L M
{ 	
	_mediator 
= 
mediator  
;  !
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
Consume !
(! "
ConsumeContext" 0
<0 1
ProductCreateEvent1 C
>C D
contextE L
)L M
{ 	
var 
command 
= 
_mapper !
.! "
Map" %
<% & 
CreateProductCommand& :
>: ;
(; <
context< C
.C D
MessageD K
)K L
;L M
await 
	_mediator 
. 
Send  
(  !
command! (
)( )
;) *
} 	
} 
} ›7
FC:\Projects\Sendeo\Assestment\online-shop\OrderMicroservice\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
builder 
. 
Services 
. 
AddSwaggerGen 
( 
)  
;  !
var 
dbConnectionString 
= 
builder  
.  !
Configuration! .
.. /

GetSection/ 9
(9 :
$str: g
)g h
.h i
Valuei n
;n o
builder 
. 
Services 
. 
	AddSqlite 
< 
OrderCommandContext .
>. /
(/ 0
dbConnectionString0 B
)B C
;C D
var !
queryConnectionString 
= 
builder #
.# $
Configuration$ 1
.1 2

GetSection2 <
(< =
$str= h
)h i
.i j
Valuej o
;o p
builder 
. 
Services 
. 
	AddSqlite 
< 
ViewContext &
>& '
(' (!
queryConnectionString( =
)= >
;> ?
builder 
. 
Services 
. 
	AddScoped 
< 
IOrderRepository +
,+ ,
OrderRepository- <
>< =
(= >
)> ?
;? @
builder 
. 
Services 
. 
	AddScoped 
<  
IOrderViewRepository /
,/ 0
OrderViewRepository1 D
>D E
(E F
)F G
;G H
builder 
. 
Services 
. 
	AddScoped 
< #
ICustomerViewRepository 2
,2 3"
CustomerViewRepository4 J
>J K
(K L
)L M
;M N
builder 
. 
Services 
. 
	AddScoped 
< "
IProductViewRepository 1
,1 2!
ProductViewRepository3 H
>H I
(I J
)J K
;K L
builder 
. 
Services 
. 

AddMediatR 
( 
typeof "
(" #
Program# *
)* +
.+ ,
Assembly, 4
)4 5
;5 6
builder 
. 
Services 
. 
AddAutoMapper 
( 
typeof %
(% &
Program& -
)- .
.. /
Assembly/ 7
)7 8
;8 9
builder"" 
."" 
Services"" 
."" 
AddMassTransit"" 
(""  
config""  &
=>""' )
{""* +
config$$ 

.$$
 
AddConsumer$$ 
<$$ '
CustomerCreateEventConsumer$$ 2
>$$2 3
($$3 4
)$$4 5
;$$5 6
config%% 

.%%
 
AddConsumer%% 
<%% &
ProductCreateEventConsumer%% 1
>%%1 2
(%%2 3
)%%3 4
;%%4 5
config&& 

.&&
 
AddConsumer&& 
<&& (
OrderViewCreateEventConsumer&& 3
>&&3 4
(&&4 5
)&&5 6
;&&6 7
config)) 

.))
 
UsingRabbitMq)) 
()) 
()) 
ctx)) 
,)) 
cfg)) "
)))" #
=>))$ &
{))' (
cfg** 
.** 
Host** 
(** 
builder** 
.** 
Configuration** &
[**& '
$str**' E
]**E F
)**F G
;**G H
cfg++ 
.++ 
ReceiveEndpoint++ 
(++ 
$str++ #
,++# $
c++% &
=>++' )
{++* +
c,, 
.,, 
ConfigureConsumer,, 
<,,  '
CustomerCreateEventConsumer,,  ;
>,,; <
(,,< =
ctx,,= @
),,@ A
;,,A B
}-- 	
)--	 

;--
 
cfg.. 
... 
ReceiveEndpoint.. 
(.. 
$str.. $
,..$ %
c..& '
=>..( *
{..+ ,
c// 
.// 
ConfigureConsumer// 
<//  &
ProductCreateEventConsumer//  :
>//: ;
(//; <
ctx//< ?
)//? @
;//@ A
}00 	
)00	 

;00
 
cfg11 
.11 
ReceiveEndpoint11 
(11 
$str11 $
,11$ %
c11& '
=>11( *
{11+ ,
c22 
.22 
ConfigureConsumer22 
<22  (
OrderViewCreateEventConsumer22  <
>22< =
(22= >
ctx22> A
)22A B
;22B C
}33 	
)33	 

;33
 
}44 
)44 
;44 
}55 
)55 
;55 
builder88 
.88 
Services88 
.88 
	AddScoped88 
<88 '
CustomerCreateEventConsumer88 6
>886 7
(887 8
)888 9
;889 :
builder99 
.99 
Services99 
.99 
	AddScoped99 
<99 &
ProductCreateEventConsumer99 5
>995 6
(996 7
)997 8
;998 9
builder:: 
.:: 
Services:: 
.:: 
	AddScoped:: 
<:: (
OrderViewCreateEventConsumer:: 7
>::7 8
(::8 9
)::9 :
;::: ;
var== 
app== 
=== 	
builder==
 
.== 
Build== 
(== 
)== 
;== 
if@@ 
(@@ 
app@@ 
.@@ 
Environment@@ 
.@@ 
IsDevelopment@@ !
(@@! "
)@@" #
)@@# $
{AA 
appBB 
.BB 

UseSwaggerBB 
(BB 
)BB 
;BB 
appCC 
.CC 
UseSwaggerUICC 
(CC 
)CC 
;CC 
}DD 
appFF 
.FF 
UseHttpsRedirectionFF 
(FF 
)FF 
;FF 
appHH 
.HH 
UseAuthorizationHH 
(HH 
)HH 
;HH 
appJJ 
.JJ 
MapControllersJJ 
(JJ 
)JJ 
;JJ 
appLL 
.LL 
RunLL 
(LL 
)LL 	
;LL	 
