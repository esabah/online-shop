Ä
[C:\Projects\Sendeo\Assestment\online-shop\CustomerMicroservice\Business\Dtos\CustomerDto.cs
	namespace 	 
CustomerMicroservice
 
. 
Business '
.' (
Dtos( ,
{ 
public 

class 
CustomerDto 
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
$num 
) 
] 
[ 	
Required	 
] 
public 
string 
Surname 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
null. 2
!2 3
;3 4
[ 	
	MaxLength	 
( 
$num 
) 
] 
[ 	
Required	 
] 
public 
string 
? 
Email 
{ 
get "
;" #
set$ '
;' (
}) *
[ 	
	MaxLength	 
( 
$num 
) 
] 
[ 	
Required	 
] 
public 
string 
? 
PhoneNumber "
{# $
get% (
;( )
set* -
;- .
}/ 0
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
? 
Address 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
DateTime 
DateOfBirth #
{$ %
get& )
;) *
set+ .
;. /
}0 1
} 
} Å
fC:\Projects\Sendeo\Assestment\online-shop\CustomerMicroservice\Business\Interfaces\ICustomerService.cs
	namespace 	 
CustomerMicroservice
 
. 
Business '
.' (

Interfaces( 2
{ 
public 

	interface 
ICustomerService %
{ 
int 
Create 
( 
CustomerDto 
customerDto *
)* +
;+ ,
IEnumerable 
< 
CustomerDto 
>  
GetAll! '
(' (
)( )
;) *
}		 
}

 Ã
eC:\Projects\Sendeo\Assestment\online-shop\CustomerMicroservice\Business\Mappers\AutoMapperProfiles.cs
	namespace 	 
CustomerMicroservice
 
. 
Business '
.' (
Mappers( /
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
< 
Customer 
, 
CustomerDto  +
>+ ,
(, -
)- .
.. /

ReverseMap/ 9
(9 :
): ;
;; <
	CreateMap 
< 
Customer 
, 
CustomerCreateEvent  3
>3 4
(4 5
)5 6
.6 7

ReverseMap7 A
(A B
)B C
;C D
} 	
} 
} ˜
cC:\Projects\Sendeo\Assestment\online-shop\CustomerMicroservice\Business\Services\CustomerService.cs
	namespace		 	 
CustomerMicroservice		
 
.		 
Business		 '
.		' (
Services		( 0
{

 
public 

class 
CustomerService  
:! "
ICustomerService# 3
{ 
private 
readonly 
ICustomerRepository ,
_customerRepository- @
;@ A
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IPublishEndpoint )
_publishEndpoint* :
;: ;
public 
CustomerService 
( 
ICustomerRepository 2
customerRepository3 E
,E F
IMapperG N
mapperO U
,U V
IPublishEndpointW g
publishEndpointh w
)w x
{ 	
_customerRepository 
=  !
customerRepository" 4
;4 5
_mapper 
= 
mapper 
; 
_publishEndpoint 
= 
publishEndpoint .
;. /
} 	
public 
int 
Create 
( 
CustomerDto %
customerDto& 1
)1 2
{ 	
var 
customerToCreate  
=! "
_mapper# *
.* +
Map+ .
<. /
CustomerDto/ :
,: ;
Customer< D
>D E
(E F
customerDtoF Q
)Q R
;R S
var 
customer 
= 
_customerRepository .
.. /
Create/ 5
(5 6
customerToCreate6 F
)F G
;G H
_customerRepository 
.  
Commit  &
(& '
)' (
;( )
var 
eventMessage 
= 
_mapper &
.& '
Map' *
<* +
Customer+ 3
,3 4
CustomerCreateEvent4 G
>G H
(H I
customerToCreateI Y
)Y Z
;Z [
_publishEndpoint   
.   
Publish   $
<  $ %
CustomerCreateEvent  % 8
>  8 9
(  9 :
eventMessage  : F
)  F G
;  G H
return"" 
customer"" 
."" 
Id"" 
;"" 
}## 	
public%% 
IEnumerable%% 
<%% 
CustomerDto%% &
>%%& '
GetAll%%( .
(%%. /
)%%/ 0
{&& 	
var'' 
	customers'' 
='' 
_customerRepository'' /
.''/ 0
GetAll''0 6
(''6 7
)''7 8
;''8 9
return(( 
_mapper(( 
.(( 
Map(( 
<(( 
IEnumerable(( *
<((* +
Customer((+ 3
>((3 4
,((4 5
IEnumerable((6 A
<((A B
CustomerDto((B M
>((M N
>((N O
(((O P
	customers((P Y
)((Y Z
;((Z [
})) 	
}** 
}++ √
`C:\Projects\Sendeo\Assestment\online-shop\CustomerMicroservice\Controllers\CustomerController.cs
	namespace 	 
CustomerMicroservice
 
. 
Controllers *
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
CustomerController
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
ICustomerService )
_customerService* :
;: ;
public 
CustomerController !
(! "
ICustomerService" 2
customerService3 B
)B C
{ 	
this 
. 
_customerService !
=" #
customerService$ 3
;3 4
} 	
[ 	
HttpPost	 
] 
public 
ActionResult 
Create "
(" #
CustomerDto# .
customerDto/ :
): ;
{ 	
var 

customerId 
= 
_customerService -
.- .
Create. 4
(4 5
customerDto5 @
)@ A
;A B
return 
Ok 
( 
$" 
$str 1
{1 2

customerId2 <
}< =
"= >
)> ?
;? @
} 	
[ 	
HttpGet	 
] 
public 
ActionResult 
< 
List  
<  !
CustomerDto! ,
>, -
>- .
GetAll/ 5
(5 6
)6 7
{ 	
return 
Ok 
( 
_customerService &
.& '
GetAll' -
(- .
). /
)/ 0
;0 1
} 	
} 
}   â
\C:\Projects\Sendeo\Assestment\online-shop\CustomerMicroservice\DataAccess\CustomerContext.cs
	namespace 	 
CustomerMicroservice
 
. 

DataAccess )
{ 
public 

class 
CustomerContext  
:! "
	DbContext# ,
{ 
public 
CustomerContext 
( 
DbContextOptions /
</ 0
CustomerContext0 ?
>? @
optionsA H
)H I
:		 	
base		
 
(		 
options		 
)		 
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
< 
Customer 
> 
	Customers (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
=7 8
null9 =
!= >
;> ?
} 
} ∂
^C:\Projects\Sendeo\Assestment\online-shop\CustomerMicroservice\DataAccess\Entities\Customer.cs
	namespace 	 
CustomerMicroservice
 
. 

DataAccess )
.) *
Entities* 2
{ 
public 

class 
Customer 
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
}+ ,
public 
DateTime 
DateOfBirth #
{$ %
get& )
;) *
set+ .
;. /
}0 1
} 
} â
lC:\Projects\Sendeo\Assestment\online-shop\CustomerMicroservice\DataAccess\Repositories\CustomerRepository.cs
	namespace 	 
CustomerMicroservice
 
. 

DataAccess )
.) *
Repositories* 6
{ 
public 

class 
CustomerRepository #
:# $
RepositoryBase% 3
<3 4
Customer4 <
>< =
,> ?
ICustomerRepository@ S
{ 
public 
CustomerRepository !
(! "
CustomerContext" 1
customerContext2 A
)A B
:C D
baseE I
(I J
customerContextJ Y
)Y Z
{		 	
}

 	
} 
} ÷
mC:\Projects\Sendeo\Assestment\online-shop\CustomerMicroservice\DataAccess\Repositories\ICustomerRepository.cs
	namespace 	 
CustomerMicroservice
 
. 

DataAccess )
.) *
Repositories* 6
{ 
public 

	interface 
ICustomerRepository (
:) *
IRepository+ 6
<6 7
Customer7 ?
>? @
{ 
} 
}		 —
IC:\Projects\Sendeo\Assestment\online-shop\CustomerMicroservice\Program.cs
var		 
builder		 
=		 
WebApplication		 
.		 
CreateBuilder		 *
(		* +
args		+ /
)		/ 0
;		0 1
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
builder 
. 
Services 
. 
AddSwaggerGen 
( 
)  
;  !
var 
dbConnectionString 
= 
builder  
.  !
Configuration! .
.. /

GetSection/ 9
(9 :
$str: g
)g h
.h i
Valuei n
;n o
builder 
. 
Services 
. 
	AddSqlite 
< 
CustomerContext *
>* +
(+ ,
dbConnectionString, >
)> ?
;? @
builder 
. 
Services 
. 
AddAutoMapper 
( 
typeof %
(% &
Program& -
)- .
.. /
Assembly/ 7
)7 8
;8 9
builder 
. 
Services 
. 
	AddScoped 
< 
ICustomerService +
,+ ,
CustomerService- <
>< =
(= >
)> ?
;? @
builder 
. 
Services 
. 
	AddScoped 
< 
ICustomerRepository .
,. /
CustomerRepository0 B
>B C
(C D
)D E
;E F
builder 
. 
Services 
. 
AddMassTransit 
(  
config  &
=>' )
{* +
config 

.
 
UsingRabbitMq 
( 
( 
ctx 
, 
cfg "
)" #
=>$ &
{' (
cfg 
. 
Host 
( 
builder 
. 
Configuration &
[& '
$str' E
]E F
)F G
;G H
} 
) 
; 
}   
)   
;   
var$$ 
app$$ 
=$$ 	
builder$$
 
.$$ 
Build$$ 
($$ 
)$$ 
;$$ 
if'' 
('' 
app'' 
.'' 
Environment'' 
.'' 
IsDevelopment'' !
(''! "
)''" #
)''# $
{(( 
app)) 
.)) 

UseSwagger)) 
()) 
))) 
;)) 
app** 
.** 
UseSwaggerUI** 
(** 
)** 
;** 
}++ 
app-- 
.-- 
UseHttpsRedirection-- 
(-- 
)-- 
;-- 
app// 
.// 
UseAuthorization// 
(// 
)// 
;// 
app11 
.11 
MapControllers11 
(11 
)11 
;11 
app33 
.33 
Run33 
(33 
)33 	
;33	 
