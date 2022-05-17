�
�C:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Datos\ServiciosCorreo\ServidorCorreoMaestro.cs
	namespace 	
Datos
 
. 
ServiciosCorreo 
{ 
public 

abstract 
class !
ServidorCorreoMaestro /
{		 
private

 

SmtpClient

 

smtpClient

 %
;

% &
	protected 
string 

senderMail #
{$ %
get& )
;) *
set+ .
;. /
}0 1
	protected 
string 
password !
{" #
get$ '
;' (
set) ,
;, -
}. /
	protected 
string 
host 
{ 
get  #
;# $
set% (
;( )
}* +
	protected 
int 
port 
{ 
get  
;  !
set" %
;% &
}' (
	protected 
bool 
ssl 
{ 
get  
;  !
set" %
;% &
}' (
	protected 
void !
inicializarSmtpClient ,
(, -
)- .
{ 	

smtpClient 
= 
new 

SmtpClient '
(' (
)( )
;) *

smtpClient 
. 
Credentials "
=# $
new% (
NetworkCredential) :
(: ;

senderMail; E
,E F
passwordG O
)O P
;P Q

smtpClient 
. 
Host 
= 
host "
;" #

smtpClient 
. 
Port 
= 
port "
;" #

smtpClient 
. 
	EnableSsl  
=! "
ssl# &
;& '
} 	
public 
void 
enviarCorreo  
(  !
string! '
asunto( .
,. /
string0 6
cuerpo7 =
,= >
List? C
<C D
stringD J
>J K
correoDestinatarioL ^
)^ _
{ 	
var 
mailMensaje 
= 
new !
MailMessage" -
(- .
). /
;/ 0
try 
{   
mailMensaje!! 
.!! 
From!!  
=!!! "
new!!# &
MailAddress!!' 2
(!!2 3

senderMail!!3 =
)!!= >
;!!> ?
foreach## 
(## 
string## 
mail##  $
in##% '
correoDestinatario##( :
)##: ;
{$$ 
mailMensaje%% 
.%%  
To%%  "
.%%" #
Add%%# &
(%%& '
mail%%' +
)%%+ ,
;%%, -
}&& 
mailMensaje(( 
.(( 
Subject(( #
=(($ %
asunto((& ,
;((, -
mailMensaje)) 
.)) 
Body))  
=))! "
cuerpo))# )
;))) *
mailMensaje** 
.** 
Priority** $
=**% &
MailPriority**' 3
.**3 4
Normal**4 :
;**: ;

smtpClient++ 
.++ 
Send++ 
(++  
mailMensaje++  +
)+++ ,
;++, -
},, 
catch-- 
(-- 
	Exception-- 
)-- 
{.. 
}.. 
finally// 
{00 
mailMensaje11 
.11 
Dispose11 #
(11# $
)11$ %
;11% &

smtpClient22 
.22 
Dispose22 "
(22" #
)22# $
;22$ %
}33 
}44 	
}55 
}66 �
�C:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Datos\ServiciosCorreo\SoporteCorreo.cs
	namespace 	
Datos
 
. 
ServiciosCorreo 
{ 
public 

class 
SoporteCorreo 
:  !
ServidorCorreoMaestro! 6
{ 
public 
SoporteCorreo 
( 
) 
{ 	

senderMail 
= 
$str /
;/ 0
password 
= 
$str "
;" #
host		 
=		 
$str		 #
;		# $
port

 
=

 
$num

 
;

 
ssl 
= 
true 
; !
inicializarSmtpClient !
(! "
)" #
;# $
} 	
} 
} �>
�C:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Datos\SqlServer\DatosClientes.cs
	namespace 	
Datos
 
{ 
public 

class 
DatosClientes 
:  
ExecuteCommandSql! 2
{ 
public

 
	DataTable

 
MostrarClientes

 (
(

( )
)

) *
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .
table 
= 
ExecuteReader !
(! "
$str" 5
)5 6
;6 7
return 
table 
; 
} 	
public 
	DataTable '
MostrarNombreCodigoClientes 4
(4 5
)5 6
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .
table 
= 
ExecuteReaderText %
(% &
$str& \
)\ ]
;] ^
return 
table 
; 
} 	
public 
	DataTable  
MostrarClienteCodigo -
(- .
int. 1
codigoCliente2 ?
)? @
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .

parameters 
= 
new 
List !
<! "
SqlParameter" .
>. /
(/ 0
)0 1
;1 2

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, <
,< =
codigoCliente> K
)K L
)L M
;M N
table 
= 
ExecuteReader !
(! "
$str" :
): ;
;; <
return   
table   
;   
}!! 	
public$$ 
	DataTable$$  
MostrarClienteNombre$$ -
($$- .
string$$. 4
nombreCliente$$5 B
)$$B C
{%% 	
	DataTable&& 
table&& 
=&& 
new&& !
	DataTable&&" +
(&&+ ,
)&&, -
;&&- .

parameters'' 
='' 
new'' 
List'' !
<''! "
SqlParameter''" .
>''. /
(''/ 0
)''0 1
;''1 2

parameters(( 
.(( 
Add(( 
((( 
new(( 
SqlParameter(( +
(((+ ,
$str((, <
,((< =
nombreCliente((> K
)((K L
)((L M
;((M N
table)) 
=)) 
ExecuteReader)) !
())! "
$str))" :
))): ;
;)); <
return** 
table** 
;** 
}++ 	
public.. 
	DataTable..  
MostrarClienteEstado.. -
(..- .
bool... 2
estado..3 9
)..9 :
{// 	
	DataTable00 
table00 
=00 
new00 !
	DataTable00" +
(00+ ,
)00, -
;00- .

parameters11 
=11 
new11 
List11 !
<11! "
SqlParameter11" .
>11. /
(11/ 0
)110 1
;111 2

parameters22 
.22 
Add22 
(22 
new22 
SqlParameter22 +
(22+ ,
$str22, 5
,225 6
estado227 =
)22= >
)22> ?
;22? @
table33 
=33 
ExecuteReader33 !
(33! "
$str33" :
)33: ;
;33; <
return44 
table44 
;44 
}55 	
public88 
void88 
InsertarCliente88 #
(88# $
string88$ *
telefono88+ 3
,883 4
int885 8
codigoDireccion889 H
,88H I
string88J P
nombreCliente88Q ^
)88^ _
{99 	

parameters:: 
=:: 
new:: 
List:: !
<::! "
SqlParameter::" .
>::. /
(::/ 0
)::0 1
;::1 2

parameters;; 
.;; 
Add;; 
(;; 
new;; 
SqlParameter;; +
(;;+ ,
$str;;, 7
,;;7 8
telefono;;9 A
);;A B
);;B C
;;;C D

parameters<< 
.<< 
Add<< 
(<< 
new<< 
SqlParameter<< +
(<<+ ,
$str<<, >
,<<> ?
codigoDireccion<<@ O
)<<O P
)<<P Q
;<<Q R

parameters== 
.== 
Add== 
(== 
new== 
SqlParameter== +
(==+ ,
$str==, <
,==< =
nombreCliente==> K
)==K L
)==L M
;==M N
ExecuteNonQuery>> 
(>> 
$str>> /
)>>/ 0
;>>0 1
}?? 	
publicBB 
voidBB 
ActualizarClienteBB %
(BB% &
stringBB& ,
telefonoBB- 5
,BB5 6
stringBB7 =
telefonoViejoBB> K
,BBK L
intBBM P
codigoDireccionBBQ `
,BB` a
stringBBb h
nombreClienteBBi v
,BBv w
intCC 
codigoClienteCC 
,CC 
boolCC #
estadoCC$ *
)CC* +
{DD 	

parametersEE 
=EE 
newEE 
ListEE !
<EE! "
SqlParameterEE" .
>EE. /
(EE/ 0
)EE0 1
;EE1 2

parametersFF 
.FF 
AddFF 
(FF 
newFF 
SqlParameterFF +
(FF+ ,
$strFF, 7
,FF7 8
telefonoFF9 A
)FFA B
)FFB C
;FFC D

parametersGG 
.GG 
AddGG 
(GG 
newGG 
SqlParameterGG +
(GG+ ,
$strGG, <
,GG< =
telefonoViejoGG> K
)GGK L
)GGL M
;GGM N

parametersHH 
.HH 
AddHH 
(HH 
newHH 
SqlParameterHH +
(HH+ ,
$strHH, >
,HH> ?
codigoDireccionHH@ O
)HHO P
)HHP Q
;HHQ R

parametersII 
.II 
AddII 
(II 
newII 
SqlParameterII +
(II+ ,
$strII, <
,II< =
nombreClienteII> K
)IIK L
)IIL M
;IIM N

parametersJJ 
.JJ 
AddJJ 
(JJ 
newJJ 
SqlParameterJJ +
(JJ+ ,
$strJJ, <
,JJ< =
codigoClienteJJ> K
)JJK L
)JJL M
;JJM N

parametersKK 
.KK 
AddKK 
(KK 
newKK 
SqlParameterKK +
(KK+ ,
$strKK, 5
,KK5 6
estadoKK7 =
)KK= >
)KK> ?
;KK? @
ExecuteNonQueryLL 
(LL 
$strLL 1
)LL1 2
;LL2 3
}MM 	
publicPP 
voidPP 
EliminarClientePP #
(PP# $
intPP$ '
codigoClientePP( 5
)PP5 6
{QQ 	

parametersRR 
=RR 
newRR 
ListRR !
<RR! "
SqlParameterRR" .
>RR. /
(RR/ 0
)RR0 1
;RR1 2

parametersSS 
.SS 
AddSS 
(SS 
newSS 
SqlParameterSS +
(SS+ ,
$strSS, <
,SS< =
codigoClienteSS> K
)SSK L
)SSL M
;SSM N
ExecuteNonQueryTT 
(TT 
$strTT /
)TT/ 0
;TT0 1
}UU 	
}VV 
}WW �f
�C:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Datos\SqlServer\DatosCotizaciones.cs
	namespace 	
Datos
 
. 
	SqlServer 
{ 
public 

class 
DatosCotizaciones "
:# $
ExecuteCommandSql% 6
{		 
public 
void 
RegistrarCotizacion '
(' (
DateTime( 0
fechaCotizacion1 @
,@ A
stringB H
descripcionI T
)T U
{ 	

parameters 
= 
new 
List !
<! "
SqlParameter" .
>. /
(/ 0
)0 1
;1 2

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, >
,> ?
fechaCotizacion@ O
)O P
)P Q
;Q R

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, :
,: ;
descripcion< G
)G H
)H I
;I J
ExecuteNonQuery 
( 
$str 3
)3 4
;4 5
} 	
public 
void '
RegistrarDetallesCotizacion /
(/ 0
int0 3
codigoUsuario4 A
,A B
intC F
codigoServicioG U
,U V
intW Z
codigoCliente[ h
,h i
int 
cantidad 
, 
float 
precio  &
)& '
{ 	

parameters 
= 
new 
List !
<! "
SqlParameter" .
>. /
(/ 0
)0 1
;1 2

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, <
,< =
codigoUsuario> K
)K L
)L M
;M N

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, =
,= >
codigoServicio? M
)M N
)N O
;O P

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, <
,< =
codigoCliente> K
)K L
)L M
;M N

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, 7
,7 8
cantidad9 A
)A B
)B C
;C D

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, 5
,5 6
precio7 =
)= >
)> ?
;? @
ExecuteNonQuery 
( 
$str ;
); <
;< =
} 	
public"" 
void"" -
!RegistrarNuevosDetallesCotizacion"" 5
(""5 6
int""6 9
codigoCotizacion"": J
,""J K
int""L O
codigoUsuario""P ]
,""] ^
string""_ e
servicio""f n
,""n o
int""p s
codigoCliente	""t �
,
""� �
int## 
cantidad## 
,## 
float## 
precio##  &
)##& '
{$$ 	

parameters%% 
=%% 
new%% 
List%% !
<%%! "
SqlParameter%%" .
>%%. /
(%%/ 0
)%%0 1
;%%1 2

parameters&& 
.&& 
Add&& 
(&& 
new&& 
SqlParameter&& +
(&&+ ,
$str&&, ?
,&&? @
codigoCotizacion&&A Q
)&&Q R
)&&R S
;&&S T

parameters'' 
.'' 
Add'' 
('' 
new'' 
SqlParameter'' +
(''+ ,
$str'', <
,''< =
codigoUsuario''> K
)''K L
)''L M
;''M N

parameters(( 
.(( 
Add(( 
((( 
new(( 
SqlParameter(( +
(((+ ,
$str((, 7
,((7 8
servicio((9 A
)((A B
)((B C
;((C D

parameters)) 
.)) 
Add)) 
()) 
new)) 
SqlParameter)) +
())+ ,
$str)), <
,))< =
codigoCliente))> K
)))K L
)))L M
;))M N

parameters** 
.** 
Add** 
(** 
new** 
SqlParameter** +
(**+ ,
$str**, 7
,**7 8
cantidad**9 A
)**A B
)**B C
;**C D

parameters++ 
.++ 
Add++ 
(++ 
new++ 
SqlParameter++ +
(+++ ,
$str++, 5
,++5 6
precio++7 =
)++= >
)++> ?
;++? @
ExecuteNonQuery,, 
(,, 
$str,, A
),,A B
;,,B C
}-- 	
public00 
void00 
EditarCotizacion00 $
(00$ %
int00% (
codigoCotizacion00) 9
,009 :
DateTime00; C
fecha00D I
,00I J
string00K Q
descripcion00R ]
)00] ^
{11 	

parameters22 
=22 
new22 
List22 !
<22! "
SqlParameter22" .
>22. /
(22/ 0
)220 1
;221 2

parameters33 
.33 
Add33 
(33 
new33 
SqlParameter33 +
(33+ ,
$str33, ?
,33? @
codigoCotizacion33A Q
)33Q R
)33R S
;33S T

parameters44 
.44 
Add44 
(44 
new44 
SqlParameter44 +
(44+ ,
$str44, 4
,444 5
fecha446 ;
)44; <
)44< =
;44= >

parameters55 
.55 
Add55 
(55 
new55 
SqlParameter55 +
(55+ ,
$str55, :
,55: ;
descripcion55< G
)55G H
)55H I
;55I J
ExecuteNonQuery66 
(66 
$str66 0
)660 1
;661 2
}77 	
public99 
void99 #
EditarDetallesCotizaion99 +
(99+ ,
int99, /#
codigoDetalleCotizacion990 G
,99G H
string99I O
servicio99P X
,99X Y
int99Z ]
codigoCliente99^ k
,99k l
int99m p
codigoUsuario99q ~
,99~ 
float:: 
precio:: 
,:: 
int:: 
cantidad:: &
)::& '
{;; 	

parameters<< 
=<< 
new<< 
List<< !
<<<! "
SqlParameter<<" .
><<. /
(<</ 0
)<<0 1
;<<1 2

parameters== 
.== 
Add== 
(== 
new== 
SqlParameter== +
(==+ ,
$str==, F
,==F G#
codigoDetalleCotizacion==H _
)==_ `
)==` a
;==a b

parameters>> 
.>> 
Add>> 
(>> 
new>> 
SqlParameter>> +
(>>+ ,
$str>>, <
,>>< =
codigoUsuario>>> K
)>>K L
)>>L M
;>>M N

parameters?? 
.?? 
Add?? 
(?? 
new?? 
SqlParameter?? +
(??+ ,
$str??, 7
,??7 8
servicio??9 A
)??A B
)??B C
;??C D

parameters@@ 
.@@ 
Add@@ 
(@@ 
new@@ 
SqlParameter@@ +
(@@+ ,
$str@@, <
,@@< =
codigoCliente@@> K
)@@K L
)@@L M
;@@M N

parametersAA 
.AA 
AddAA 
(AA 
newAA 
SqlParameterAA +
(AA+ ,
$strAA, 7
,AA7 8
cantidadAA9 A
)AAA B
)AAB C
;AAC D

parametersBB 
.BB 
AddBB 
(BB 
newBB 
SqlParameterBB +
(BB+ ,
$strBB, 5
,BB5 6
precioBB7 =
)BB= >
)BB> ?
;BB? @
ExecuteNonQueryCC 
(CC 
$strCC 8
)CC8 9
;CC9 :
}DD 	
publicGG 
	DataTableGG #
ObtenerCodigoCotizacionGG 0
(GG0 1
)GG1 2
{HH 	
	DataTableII 
tableII 
=II 
newII !
	DataTableII" +
(II+ ,
)II, -
;II- .
tableJJ 
=JJ 
ExecuteReaderTextJJ %
(JJ% &
$strJJ& X
)JJX Y
;JJY Z
returnKK 
tableKK 
;KK 
}LL 	
publicOO 
	DataTableOO .
"ObtenenerDetallesCotizacionCodigosOO ;
(OO; <
intOO< ?
codigoCotizacionOO@ P
)OOP Q
{PP 	
	DataTableQQ 
tableQQ 
=QQ 
newQQ !
	DataTableQQ" +
(QQ+ ,
)QQ, -
;QQ- .

parametersRR 
=RR 
newRR 
ListRR !
<RR! "
SqlParameterRR" .
>RR. /
(RR/ 0
)RR0 1
;RR1 2

parametersSS 
.SS 
AddSS 
(SS 
newSS 
SqlParameterSS +
(SS+ ,
$strSS, ?
,SS? @
codigoCotizacionSSA Q
)SSQ R
)SSR S
;SSS T
tableTT 
=TT 
ExecuteReaderTextTT %
(TT% &
$str	TT& �
)
TT� �
;
TT� �
returnUU 
tableUU 
;UU 
}VV 	
publicYY 
voidYY 
AprobarCotizacionYY %
(YY% &
intYY& )
codigoYY* 0
,YY0 1
boolYY2 6
estadoYY7 =
)YY= >
{ZZ 	

parameters[[ 
=[[ 
new[[ 
List[[ !
<[[! "
SqlParameter[[" .
>[[. /
([[/ 0
)[[0 1
;[[1 2

parameters\\ 
.\\ 
Add\\ 
(\\ 
new\\ 
SqlParameter\\ +
(\\+ ,
$str\\, 5
,\\5 6
codigo\\7 =
)\\= >
)\\> ?
;\\? @

parameters]] 
.]] 
Add]] 
(]] 
new]] 
SqlParameter]] +
(]]+ ,
$str]], 5
,]]5 6
estado]]7 =
)]]= >
)]]> ?
;]]? @
ExecuteNonQueryText^^ 
(^^  
$str^^  a
)^^a b
;^^b c
}__ 	
publicbb 
voidbb 
EliminarCotizacionbb &
(bb& '
intbb' *
codigobb+ 1
)bb1 2
{cc 	

parametersdd 
=dd 
newdd 
Listdd !
<dd! "
SqlParameterdd" .
>dd. /
(dd/ 0
)dd0 1
;dd1 2

parametersee 
.ee 
Addee 
(ee 
newee 
SqlParameteree +
(ee+ ,
$stree, 5
,ee5 6
codigoee7 =
)ee= >
)ee> ?
;ee? @
ExecuteNonQueryTextff 
(ff  
$strff  Q
)ffQ R
;ffR S
}gg 	
publicjj 
voidjj &
EliminarDetallesCotizacionjj .
(jj. /
intjj/ 2
codigojj3 9
)jj9 :
{kk 	

parametersll 
=ll 
newll 
Listll !
<ll! "
SqlParameterll" .
>ll. /
(ll/ 0
)ll0 1
;ll1 2

parametersmm 
.mm 
Addmm 
(mm 
newmm 
SqlParametermm +
(mm+ ,
$strmm, 5
,mm5 6
codigomm7 =
)mm= >
)mm> ?
;mm? @
ExecuteNonQueryTextnn 
(nn  
$strnn  b
)nnb c
;nnc d
}oo 	
publicrr 
voidrr /
#EliminarDetallesCotizacionPorCodigorr 7
(rr7 8
intrr8 ;
codigorr< B
)rrB C
{ss 	

parameterstt 
=tt 
newtt 
Listtt !
<tt! "
SqlParametertt" .
>tt. /
(tt/ 0
)tt0 1
;tt1 2

parametersuu 
.uu 
Adduu 
(uu 
newuu 
SqlParameteruu +
(uu+ ,
$struu, 5
,uu5 6
codigouu7 =
)uu= >
)uu> ?
;uu? @
ExecuteNonQueryTextvv 
(vv  
$strvv  W
)vvW X
;vvX Y
}ww 	
}xx 
}yy �
�C:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Datos\SqlServer\DatosDirecciones.cs
	namespace 	
Datos
 
{ 
public 

class 
DatosDirecciones !
:" #
ExecuteCommandSql$ 5
{ 
public

 
	DataTable

 
MostrarDirecciones

 +
(

+ ,
)

, -
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .
table 
= 
ExecuteReaderText %
(% &
$str& Q
)Q R
;R S
return 
table 
; 
} 	
public 
void 
InsertarDireccion %
(% &
string& ,
	direccion- 6
)6 7
{ 	

parameters 
= 
new 
List !
<! "
SqlParameter" .
>. /
(/ 0
)0 1
;1 2

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, 8
,8 9
	direccion: C
)C D
)D E
;E F
ExecuteNonQuery 
( 
$str 1
)1 2
;2 3
} 	
public 
void 
ActualizaDireccion &
(& '
string' -
	direccion. 7
,7 8
string9 ?
direccionActualizar@ S
)S T
{ 	

parameters 
= 
new 
List !
<! "
SqlParameter" .
>. /
(/ 0
)0 1
;1 2

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, 8
,8 9
	direccion: C
)C D
)D E
;E F

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, B
,B C
direccionActualizarD W
)W X
)X Y
;Y Z
ExecuteNonQuery 
( 
$str 3
)3 4
;4 5
}   	
}!! 
}"" �
�C:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Datos\SqlServer\DatosEntradas.cs
	namespace 	
Datos
 
{ 
public 

class 
DatosEntradas 
:  
ExecuteCommandSql! 2
{ 
public		 
void		 
RegistrarEntrada		 $
(		$ %
DateTime		% -
fechaEntrada		. :
)		: ;
{

 	

parameters 
= 
new 
List !
<! "
SqlParameter" .
>. /
(/ 0
)0 1
;1 2

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, ;
,; <
fechaEntrada= I
)I J
)J K
;K L
ExecuteNonQuery 
( 
$str 0
)0 1
;1 2
} 	
public 
void #
RegistrarDetalleEntrada +
(+ ,
int, /
codigoUsuario0 =
,= >
string? E
suplidorF N
,N O
string 
material 
, 
int !
cantidad" *
,* +
float, 1
costo2 7
)7 8
{ 	

parameters 
= 
new 
List !
<! "
SqlParameter" .
>. /
(/ 0
)0 1
;1 2

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, <
,< =
codigoUsuario> K
)K L
)L M
;M N

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, 7
,7 8
suplidor9 A
)A B
)B C
;C D

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, 7
,7 8
material9 A
)A B
)B C
;C D

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, 7
,7 8
cantidad9 A
)A B
)B C
;C D

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, 4
,4 5
costo6 ;
); <
)< =
;= >
ExecuteNonQuery 
( 
$str 7
)7 8
;8 9
} 	
} 
} ��
�C:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Datos\SqlServer\DatosMateriales.cs
	namespace 	
Datos
 
{ 
public 

class 
DatosMateriales  
:! "
ExecuteCommandSql# 4
{ 
public

 
	DataTable

 
MostrarMateriales

 *
(

* +
)

+ ,
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .
table 
= 
ExecuteReader !
(! "
$str" 7
)7 8
;8 9
return 
table 
; 
} 	
public 
	DataTable "
NombreCodigoMateriales /
(/ 0
)0 1
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .
table 
= 
ExecuteReaderText %
(% &
$str& l
)l m
;m n
return 
table 
; 
} 	
public 
	DataTable 
BuscarCostoMaterial ,
(, -
int- 0
codigoMaterial1 ?
)? @
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .

parameters 
= 
new 
List !
<! "
SqlParameter" .
>. /
(/ 0
)0 1
;1 2

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, =
,= >
codigoMaterial? M
)M N
)N O
;O P
table 
= 
ExecuteReaderText %
(% &
$str& c
)c d
;d e
return   
table   
;   
}!! 	
public$$ 
	DataTable$$ 
PuntoReorden$$ %
($$% &
)$$& '
{%% 	
	DataTable&& 
table&& 
=&& 
new&& !
	DataTable&&" +
(&&+ ,
)&&, -
;&&- .
table'' 
='' 
ExecuteReaderText'' %
(''% &
$str''& c
)''c d
;''d e
return(( 
table(( 
;(( 
})) 	
public,, 
	DataTable,, "
BuscarMaterialesCodigo,, /
(,,/ 0
int,,0 3
codigo,,4 :
),,: ;
{-- 	
	DataTable.. 
table.. 
=.. 
new.. !
	DataTable.." +
(..+ ,
).., -
;..- .

parameters// 
=// 
new// 
List// !
<//! "
SqlParameter//" .
>//. /
(/// 0
)//0 1
;//1 2

parameters00 
.00 
Add00 
(00 
new00 
SqlParameter00 +
(00+ ,
$str00, 5
,005 6
codigo007 =
)00= >
)00> ?
;00? @
table11 
=11 
ExecuteReader11 !
(11! "
$str11" <
)11< =
;11= >
return22 
table22 
;22 
}33 	
public66 
	DataTable66 "
BuscarMaterialesNombre66 /
(66/ 0
string660 6
nombre667 =
)66= >
{77 	
	DataTable88 
table88 
=88 
new88 !
	DataTable88" +
(88+ ,
)88, -
;88- .

parameters99 
=99 
new99 
List99 !
<99! "
SqlParameter99" .
>99. /
(99/ 0
)990 1
;991 2

parameters:: 
.:: 
Add:: 
(:: 
new:: 
SqlParameter:: +
(::+ ,
$str::, 5
,::5 6
nombre::7 =
)::= >
)::> ?
;::? @
table;; 
=;; 
ExecuteReader;; !
(;;! "
$str;;" <
);;< =
;;;= >
return<< 
table<< 
;<< 
}== 	
public@@ 
	DataTable@@ "
BuscarMaterialesEstado@@ /
(@@/ 0
bool@@0 4
estado@@5 ;
)@@; <
{AA 	
	DataTableBB 
tableBB 
=BB 
newBB !
	DataTableBB" +
(BB+ ,
)BB, -
;BB- .

parametersCC 
=CC 
newCC 
ListCC !
<CC! "
SqlParameterCC" .
>CC. /
(CC/ 0
)CC0 1
;CC1 2

parametersDD 
.DD 
AddDD 
(DD 
newDD 
SqlParameterDD +
(DD+ ,
$strDD, 5
,DD5 6
estadoDD7 =
)DD= >
)DD> ?
;DD? @
tableEE 
=EE 
ExecuteReaderEE !
(EE! "
$strEE" <
)EE< =
;EE= >
returnFF 
tableFF 
;FF 
}GG 	
publicJJ 
	DataTableJJ !
MostrarTipoMaterialesJJ .
(JJ. /
)JJ/ 0
{KK 	
	DataTableLL 
tableLL 
=LL 
newLL !
	DataTableLL" +
(LL+ ,
)LL, -
;LL- .
tableMM 
=MM 
ExecuteReaderTextMM %
(MM% &
$strMM& W
)MMW X
;MMX Y
returnNN 
tableNN 
;NN 
}OO 	
publicRR 
	DataTableRR '
MostrarExcedentesMaterialesRR 4
(RR4 5
)RR5 6
{SS 	
	DataTableTT 
tableTT 
=TT 
newTT !
	DataTableTT" +
(TT+ ,
)TT, -
;TT- .
tableUU 
=UU 
ExecuteReaderUU !
(UU! "
$strUU" A
)UUA B
;UUB C
returnVV 
tableVV 
;VV 
}WW 	
publicZZ 
voidZZ 
RegistrarMaterialZZ %
(ZZ% &
intZZ& )
codigo_tipoMaterialZZ* =
,ZZ= >
stringZZ? E
nombreZZF L
,ZZL M
stringZZN T
descripcionZZU `
,ZZ` a
float[[ 
costo[[ 
,[[ 
int[[ 

existencia[[ '
)[[' (
{\\ 	

parameters]] 
=]] 
new]] 
List]] !
<]]! "
SqlParameter]]" .
>]]. /
(]]/ 0
)]]0 1
;]]1 2

parameters^^ 
.^^ 
Add^^ 
(^^ 
new^^ 
SqlParameter^^ +
(^^+ ,
$str^^, B
,^^B C
codigo_tipoMaterial^^D W
)^^W X
)^^X Y
;^^Y Z

parameters__ 
.__ 
Add__ 
(__ 
new__ 
SqlParameter__ +
(__+ ,
$str__, 5
,__5 6
nombre__7 =
)__= >
)__> ?
;__? @

parameters`` 
.`` 
Add`` 
(`` 
new`` 
SqlParameter`` +
(``+ ,
$str``, :
,``: ;
descripcion``< G
)``G H
)``H I
;``I J

parametersaa 
.aa 
Addaa 
(aa 
newaa 
SqlParameteraa +
(aa+ ,
$straa, 4
,aa4 5
costoaa6 ;
)aa; <
)aa< =
;aa= >

parametersbb 
.bb 
Addbb 
(bb 
newbb 
SqlParameterbb +
(bb+ ,
$strbb, 9
,bb9 :

existenciabb; E
)bbE F
)bbF G
;bbG H
ExecuteNonQuerycc 
(cc 
$strcc 0
)cc0 1
;cc1 2
}dd 	
publicgg 
voidgg 
ActualizarMaterialgg &
(gg& '
intgg' *
codigoMaterialgg+ 9
,gg9 :
intgg; >
codigo_tipoMaterialgg? R
,ggR S
stringggT Z
nombregg[ a
,gga b
stringggc i
descripcionggj u
,ggu v
floathh 
costohh 
,hh 
inthh 

existenciahh '
,hh' (
boolhh) -
estadohh. 4
)hh4 5
{ii 	

parametersjj 
=jj 
newjj 
Listjj !
<jj! "
SqlParameterjj" .
>jj. /
(jj/ 0
)jj0 1
;jj1 2

parameterskk 
.kk 
Addkk 
(kk 
newkk 
SqlParameterkk +
(kk+ ,
$strkk, =
,kk= >
codigoMaterialkk? M
)kkM N
)kkN O
;kkO P

parametersll 
.ll 
Addll 
(ll 
newll 
SqlParameterll +
(ll+ ,
$strll, B
,llB C
codigo_tipoMaterialllD W
)llW X
)llX Y
;llY Z

parametersmm 
.mm 
Addmm 
(mm 
newmm 
SqlParametermm +
(mm+ ,
$strmm, 5
,mm5 6
nombremm7 =
)mm= >
)mm> ?
;mm? @

parametersnn 
.nn 
Addnn 
(nn 
newnn 
SqlParameternn +
(nn+ ,
$strnn, :
,nn: ;
descripcionnn< G
)nnG H
)nnH I
;nnI J

parametersoo 
.oo 
Addoo 
(oo 
newoo 
SqlParameteroo +
(oo+ ,
$stroo, 4
,oo4 5
costooo6 ;
)oo; <
)oo< =
;oo= >

parameterspp 
.pp 
Addpp 
(pp 
newpp 
SqlParameterpp +
(pp+ ,
$strpp, 9
,pp9 :

existenciapp; E
)ppE F
)ppF G
;ppG H

parametersqq 
.qq 
Addqq 
(qq 
newqq 
SqlParameterqq +
(qq+ ,
$strqq, 5
,qq5 6
estadoqq7 =
)qq= >
)qq> ?
;qq? @
ExecuteNonQueryrr 
(rr 
$strrr 2
)rr2 3
;rr3 4
}ss 	
publicvv 
voidvv 
EliminarMaterialvv $
(vv$ %
intvv% (
codigovv) /
)vv/ 0
{ww 	

parametersxx 
=xx 
newxx 
Listxx !
<xx! "
SqlParameterxx" .
>xx. /
(xx/ 0
)xx0 1
;xx1 2

parametersyy 
.yy 
Addyy 
(yy 
newyy 
SqlParameteryy +
(yy+ ,
$stryy, 5
,yy5 6
codigoyy7 =
)yy= >
)yy> ?
;yy? @
ExecuteNonQueryzz 
(zz 
$strzz 0
)zz0 1
;zz1 2
}{{ 	
public~~ 
void~~ !
RegistrarTipoMaterial~~ )
(~~) *
string~~* 0
nombre~~1 7
)~~7 8
{ 	

parameters
�� 
=
�� 
new
�� 
List
�� !
<
��! "
SqlParameter
��" .
>
��. /
(
��/ 0
)
��0 1
;
��1 2

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 5
,
��5 6
nombre
��7 =
)
��= >
)
��> ?
;
��? @
ExecuteNonQuery
�� 
(
�� 
$str
�� 4
)
��4 5
;
��5 6
}
�� 	
public
�� 
void
�� $
ActualizarTipoMaterial
�� *
(
��* +
string
��+ 1
nombre
��2 8
,
��8 9
string
��: @
nombreNuevo
��A L
)
��L M
{
�� 	

parameters
�� 
=
�� 
new
�� 
List
�� !
<
��! "
SqlParameter
��" .
>
��. /
(
��/ 0
)
��0 1
;
��1 2

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 5
,
��5 6
nombre
��7 =
)
��= >
)
��> ?
;
��? @

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, @
,
��@ A
nombreNuevo
��B M
)
��M N
)
��N O
;
��O P
ExecuteNonQuery
�� 
(
�� 
$str
�� 6
)
��6 7
;
��7 8
}
�� 	
public
�� 
void
�� &
RegistrarExcenteMaterial
�� ,
(
��, -
string
��- 3
tipoMaterial
��4 @
,
��@ A
int
��B E
codigoMaterial
��F T
,
��T U
int
�� 
codigoMedida
�� 
,
�� 
string
�� $
largo
��% *
,
��* +
string
��, 2
ancho
��3 8
,
��8 9
string
��: @
alto
��A E
,
��E F
int
��G J
cantidad
��K S
,
��S T
string
��U [
descripcion
��\ g
)
��g h
{
�� 	

parameters
�� 
=
�� 
new
�� 
List
�� !
<
��! "
SqlParameter
��" .
>
��. /
(
��/ 0
)
��0 1
;
��1 2

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, ;
,
��; <
tipoMaterial
��= I
)
��I J
)
��J K
;
��K L

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, =
,
��= >
codigoMaterial
��? M
)
��M N
)
��N O
;
��O P

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, ;
,
��; <
codigoMedida
��= I
)
��I J
)
��J K
;
��K L

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 4
,
��4 5
largo
��6 ;
)
��; <
)
��< =
;
��= >

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 4
,
��4 5
ancho
��6 ;
)
��; <
)
��< =
;
��= >

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 3
,
��3 4
alto
��5 9
)
��9 :
)
��: ;
;
��; <

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 7
,
��7 8
cantidad
��9 A
)
��A B
)
��B C
;
��C D

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, :
,
��: ;
descripcion
��< G
)
��G H
)
��H I
;
��I J
ExecuteNonQuery
�� 
(
�� 
$str
�� 9
)
��9 :
;
��: ;
}
�� 	
public
�� 
void
�� )
ActualizarCantidadExcedente
�� /
(
��/ 0
int
��0 3
codigo
��4 :
,
��: ;
int
��< ?
cantidad
��@ H
)
��H I
{
�� 	

parameters
�� 
=
�� 
new
�� 
List
�� !
<
��! "
SqlParameter
��" .
>
��. /
(
��/ 0
)
��0 1
;
��1 2

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 7
,
��7 8
cantidad
��9 A
)
��A B
)
��B C
;
��C D

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 5
,
��5 6
codigo
��7 =
)
��= >
)
��> ?
;
��? @!
ExecuteNonQueryText
�� 
(
��  
$str
��  N
+
��O P
$str
�� X
)
��X Y
;
��Y Z
}
�� 	
public
�� 
void
�� )
ActualizarExcedenteMaterial
�� /
(
��/ 0
int
��0 3
codigoExcedente
��4 C
,
��C D
int
��E H
codigoMedida
��I U
,
��U V
string
�� 
largo
�� 
,
�� 
string
��  
ancho
��! &
,
��& '
string
��( .
alto
��/ 3
,
��3 4
int
��5 8
cantidad
��9 A
,
��A B
string
��C I
descripcion
��J U
)
��U V
{
�� 	

parameters
�� 
=
�� 
new
�� 
List
�� !
<
��! "
SqlParameter
��" .
>
��. /
(
��/ 0
)
��0 1
;
��1 2

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, ?
,
��? @
codigoExcedente
��A P
)
��P Q
)
��Q R
;
��R S

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, ;
,
��; <
codigoMedida
��= I
)
��I J
)
��J K
;
��K L

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 4
,
��4 5
largo
��6 ;
)
��; <
)
��< =
;
��= >

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 4
,
��4 5
ancho
��6 ;
)
��; <
)
��< =
;
��= >

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 3
,
��3 4
alto
��5 9
)
��9 :
)
��: ;
;
��; <

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 7
,
��7 8
cantidad
��9 A
)
��A B
)
��B C
;
��C D

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, :
,
��: ;
descripcion
��< G
)
��G H
)
��H I
;
��I J
ExecuteNonQuery
�� 
(
�� 
$str
�� ;
)
��; <
;
��< =
}
�� 	
public
�� 
void
�� '
EliminarExcedenteMaterial
�� -
(
��- .
int
��. 1
codigoExcedente
��2 A
)
��A B
{
�� 	

parameters
�� 
=
�� 
new
�� 
List
�� !
<
��! "
SqlParameter
��" .
>
��. /
(
��/ 0
)
��0 1
;
��1 2

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, >
,
��> ?
codigoExcedente
��@ O
)
��O P
)
��P Q
;
��Q R
ExecuteNonQuery
�� 
(
�� 
$str
�� 9
)
��9 :
;
��: ;
}
�� 	
}
�� 
}�� �
�C:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Datos\SqlServer\DatosMedidas.cs
	namespace 	
Datos
 
{ 
public 

class 
DatosMedidas 
: 
ExecuteCommandSql  1
{ 
public 
	DataTable 
MostrarMedidas '
(' (
)( )
{		 	
	DataTable

 
table

 
=

 
new

 !
	DataTable

" +
(

+ ,
)

, -
;

- .
table 
= 
ExecuteReaderText %
(% &
$str& Z
)Z [
;[ \
return 
table 
; 
} 	
} 
} �>
�C:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Datos\SqlServer\DatosProveedores.cs
	namespace 	
Datos
 
{ 
public 

class 
DatosProveedores !
:" #
ExecuteCommandSql$ 5
{ 
public

 
	DataTable

 
MostrarProveedores

 +
(

+ ,
)

, -
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .
table 
= 
ExecuteReader !
(! "
$str" 8
)8 9
;9 :
return 
table 
; 
} 	
public 
	DataTable #
NombreCodigoProveedores 0
(0 1
)1 2
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .
table 
= 
ExecuteReaderText %
(% &
$str& _
)_ `
;` a
return 
table 
; 
} 	
public 
	DataTable !
BuscarProveedorCodigo .
(. /
int/ 2
codigo3 9
)9 :
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .

parameters 
= 
new 
List !
<! "
SqlParameter" .
>. /
(/ 0
)0 1
;1 2

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, 5
,5 6
codigo7 =
)= >
)> ?
;? @
table 
= 
ExecuteReader !
(! "
$str" ;
); <
;< =
return   
table   
;   
}!! 	
public$$ 
	DataTable$$ !
BuscarProveedorNombre$$ .
($$. /
string$$/ 5
nombre$$6 <
)$$< =
{%% 	
	DataTable&& 
table&& 
=&& 
new&& !
	DataTable&&" +
(&&+ ,
)&&, -
;&&- .

parameters'' 
='' 
new'' 
List'' !
<''! "
SqlParameter''" .
>''. /
(''/ 0
)''0 1
;''1 2

parameters(( 
.(( 
Add(( 
((( 
new(( 
SqlParameter(( +
(((+ ,
$str((, 5
,((5 6
nombre((7 =
)((= >
)((> ?
;((? @
table)) 
=)) 
ExecuteReader)) !
())! "
$str))" ;
))); <
;))< =
return** 
table** 
;** 
}++ 	
public.. 
	DataTable.. !
BuscarProveedorEstado.. .
(... /
bool../ 3
estado..4 :
)..: ;
{// 	
	DataTable00 
table00 
=00 
new00 !
	DataTable00" +
(00+ ,
)00, -
;00- .

parameters11 
=11 
new11 
List11 !
<11! "
SqlParameter11" .
>11. /
(11/ 0
)110 1
;111 2

parameters22 
.22 
Add22 
(22 
new22 
SqlParameter22 +
(22+ ,
$str22, 5
,225 6
estado227 =
)22= >
)22> ?
;22? @
table33 
=33 
ExecuteReader33 !
(33! "
$str33" ;
)33; <
;33< =
return44 
table44 
;44 
}55 	
public88 
void88 
RegistrarProveedor88 &
(88& '
string88' -
telefono88. 6
,886 7
int888 ;
codigoDireccion88< K
,88K L
string88M S
nombreProveedor88T c
)88c d
{99 	

parameters:: 
=:: 
new:: 
List:: !
<::! "
SqlParameter::" .
>::. /
(::/ 0
)::0 1
;::1 2

parameters;; 
.;; 
Add;; 
(;; 
new;; 
SqlParameter;; +
(;;+ ,
$str;;, 7
,;;7 8
telefono;;9 A
);;A B
);;B C
;;;C D

parameters<< 
.<< 
Add<< 
(<< 
new<< 
SqlParameter<< +
(<<+ ,
$str<<, >
,<<> ?
codigoDireccion<<@ O
)<<O P
)<<P Q
;<<Q R

parameters== 
.== 
Add== 
(== 
new== 
SqlParameter== +
(==+ ,
$str==, >
,==> ?
nombreProveedor==@ O
)==O P
)==P Q
;==Q R
ExecuteNonQuery>> 
(>> 
$str>> 1
)>>1 2
;>>2 3
}?? 	
publicBB 
voidBB 
ActualizarProveedorBB '
(BB' (
stringBB( .
telefonoBB/ 7
,BB7 8
stringBB9 ?
telefonoViejoBB@ M
,BBM N
intBBO R
codigoDireccionBBS b
,BBb c
stringBBd j
nombreProveedorBBk z
,BBz {
intCC 
codigoProveedorCC 
,CC  
boolCC! %
estadoCC& ,
)CC, -
{DD 	

parametersEE 
=EE 
newEE 
ListEE !
<EE! "
SqlParameterEE" .
>EE. /
(EE/ 0
)EE0 1
;EE1 2

parametersFF 
.FF 
AddFF 
(FF 
newFF 
SqlParameterFF +
(FF+ ,
$strFF, 7
,FF7 8
telefonoFF9 A
)FFA B
)FFB C
;FFC D

parametersGG 
.GG 
AddGG 
(GG 
newGG 
SqlParameterGG +
(GG+ ,
$strGG, <
,GG< =
telefonoViejoGG> K
)GGK L
)GGL M
;GGM N

parametersHH 
.HH 
AddHH 
(HH 
newHH 
SqlParameterHH +
(HH+ ,
$strHH, >
,HH> ?
codigoDireccionHH@ O
)HHO P
)HHP Q
;HHQ R

parametersII 
.II 
AddII 
(II 
newII 
SqlParameterII +
(II+ ,
$strII, >
,II> ?
nombreProveedorII@ O
)IIO P
)IIP Q
;IIQ R

parametersJJ 
.JJ 
AddJJ 
(JJ 
newJJ 
SqlParameterJJ +
(JJ+ ,
$strJJ, >
,JJ> ?
codigoProveedorJJ@ O
)JJO P
)JJP Q
;JJQ R

parametersKK 
.KK 
AddKK 
(KK 
newKK 
SqlParameterKK +
(KK+ ,
$strKK, 5
,KK5 6
estadoKK7 =
)KK= >
)KK> ?
;KK? @
ExecuteNonQueryLL 
(LL 
$strLL 3
)LL3 4
;LL4 5
}MM 	
publicPP 
voidPP 
EliminarProveedorPP %
(PP% &
intPP& )
codigoProveedorPP* 9
)PP9 :
{QQ 	

parametersRR 
=RR 
newRR 
ListRR !
<RR! "
SqlParameterRR" .
>RR. /
(RR/ 0
)RR0 1
;RR1 2

parametersSS 
.SS 
AddSS 
(SS 
newSS 
SqlParameterSS +
(SS+ ,
$strSS, >
,SS> ?
codigoProveedorSS@ O
)SSO P
)SSP Q
;SSQ R
ExecuteNonQueryTT 
(TT 
$strTT 1
)TT1 2
;TT2 3
}UU 	
}VV 
}WW �\
�C:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Datos\SqlServer\DatosReportes.cs
	namespace 	
Datos
 
{ 
public 

class 
DatosReportes 
:  
ExecuteCommandSql! 2
{		 
public 
	DataTable !
ReporteEntradaGeneral .
(. /
DateTime/ 7
fechaInicial8 D
,D E
DateTimeF N

fechaFinalO Y
)Y Z
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .

parameters 
= 
new 
List !
<! "
SqlParameter" .
>. /
(/ 0
)0 1
;1 2

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, ;
,; <
fechaInicial= I
)I J
)J K
;K L

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, 9
,9 :

fechaFinal; E
)E F
)F G
;G H
table 
= 
ExecuteReader !
(! "
$str" <
)< =
;= >
return 
table 
; 
} 	
public 
	DataTable #
ReporteEntradaDetallado 0
(0 1
DateTime1 9
fechaInicial: F
,F G
DateTimeH P

fechaFinalQ [
)[ \
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .

parameters 
= 
new 
List !
<! "
SqlParameter" .
>. /
(/ 0
)0 1
;1 2

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, ;
,; <
fechaInicial= I
)I J
)J K
;K L

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, 9
,9 :

fechaFinal; E
)E F
)F G
;G H
table 
= 
ExecuteReader !
(! "
$str" >
)> ?
;? @
return 
table 
; 
} 	
public!! 
	DataTable!! !
ReporteSalidasGeneral!! .
(!!. /
DateTime!!/ 7
fechaInicial!!8 D
,!!D E
DateTime!!F N

fechaFinal!!O Y
)!!Y Z
{"" 	
	DataTable## 
table## 
=## 
new## !
	DataTable##" +
(##+ ,
)##, -
;##- .

parameters$$ 
=$$ 
new$$ 
List$$ !
<$$! "
SqlParameter$$" .
>$$. /
($$/ 0
)$$0 1
;$$1 2

parameters%% 
.%% 
Add%% 
(%% 
new%% 
SqlParameter%% +
(%%+ ,
$str%%, ;
,%%; <
fechaInicial%%= I
)%%I J
)%%J K
;%%K L

parameters&& 
.&& 
Add&& 
(&& 
new&& 
SqlParameter&& +
(&&+ ,
$str&&, 9
,&&9 :

fechaFinal&&; E
)&&E F
)&&F G
;&&G H
table'' 
='' 
ExecuteReader'' !
(''! "
$str''" ;
)''; <
;''< =
return(( 
table(( 
;(( 
})) 	
public,, 
	DataTable,, #
ReporteSalidasDetallado,, 0
(,,0 1
DateTime,,1 9
fechaInicial,,: F
,,,F G
DateTime,,H P

fechaFinal,,Q [
),,[ \
{-- 	
	DataTable.. 
table.. 
=.. 
new.. !
	DataTable.." +
(..+ ,
).., -
;..- .

parameters// 
=// 
new// 
List// !
<//! "
SqlParameter//" .
>//. /
(/// 0
)//0 1
;//1 2

parameters00 
.00 
Add00 
(00 
new00 
SqlParameter00 +
(00+ ,
$str00, ;
,00; <
fechaInicial00= I
)00I J
)00J K
;00K L

parameters11 
.11 
Add11 
(11 
new11 
SqlParameter11 +
(11+ ,
$str11, 9
,119 :

fechaFinal11; E
)11E F
)11F G
;11G H
table22 
=22 
ExecuteReader22 !
(22! "
$str22" =
)22= >
;22> ?
return33 
table33 
;33 
}44 	
public77 
	DataTable77 !
ConsultarCotizaciones77 .
(77. /
DateTime77/ 7
fechaInicial778 D
,77D E
DateTime77F N

fechaFinal77O Y
)77Y Z
{88 	
	DataTable99 
table99 
=99 
new99 !
	DataTable99" +
(99+ ,
)99, -
;99- .

parameters:: 
=:: 
new:: 
List:: !
<::! "
SqlParameter::" .
>::. /
(::/ 0
)::0 1
;::1 2

parameters;; 
.;; 
Add;; 
(;; 
new;; 
SqlParameter;; +
(;;+ ,
$str;;, ;
,;;; <
fechaInicial;;= I
);;I J
);;J K
;;;K L

parameters<< 
.<< 
Add<< 
(<< 
new<< 
SqlParameter<< +
(<<+ ,
$str<<, 9
,<<9 :

fechaFinal<<; E
)<<E F
)<<F G
;<<G H
table== 
=== 
ExecuteReader== !
(==! "
$str==" ;
)==; <
;==< =
return>> 
table>> 
;>> 
}?? 	
publicBB 
	DataTableBB *
ConsultarCotizacionesPorCodigoBB 7
(BB7 8
intBB8 ;
codigoBB< B
)BBB C
{CC 	
	DataTableDD 
tableDD 
=DD 
newDD !
	DataTableDD" +
(DD+ ,
)DD, -
;DD- .

parametersEE 
=EE 
newEE 
ListEE !
<EE! "
SqlParameterEE" .
>EE. /
(EE/ 0
)EE0 1
;EE1 2

parametersFF 
.FF 
AddFF 
(FF 
newFF 
SqlParameterFF +
(FF+ ,
$strFF, 5
,FF5 6
codigoFF7 =
)FF= >
)FF> ?
;FF? @
tableGG 
=GG 
ExecuteReaderGG !
(GG! "
$strGG" A
)GGA B
;GGB C
returnHH 
tableHH 
;HH 
}II 	
publicLL 
	DataTableLL /
#ConsultarCotizacionesPorDescripcionLL <
(LL< =
stringLL= C
descripcionLLD O
)LLO P
{MM 	
	DataTableNN 
tableNN 
=NN 
newNN !
	DataTableNN" +
(NN+ ,
)NN, -
;NN- .

parametersOO 
=OO 
newOO 
ListOO !
<OO! "
SqlParameterOO" .
>OO. /
(OO/ 0
)OO0 1
;OO1 2

parametersPP 
.PP 
AddPP 
(PP 
newPP 
SqlParameterPP +
(PP+ ,
$strPP, :
,PP: ;
descripcionPP< G
)PPG H
)PPH I
;PPI J
tableQQ 
=QQ 
ExecuteReaderQQ !
(QQ! "
$strQQ" F
)QQF G
;QQG H
returnRR 
tableRR 
;RR 
}SS 	
publicVV 
	DataTableVV +
ConsultarCotizacionesPorClienteVV 8
(VV8 9
stringVV9 ?
clienteVV@ G
)VVG H
{WW 	
	DataTableXX 
tableXX 
=XX 
newXX !
	DataTableXX" +
(XX+ ,
)XX, -
;XX- .

parametersYY 
=YY 
newYY 
ListYY !
<YY! "
SqlParameterYY" .
>YY. /
(YY/ 0
)YY0 1
;YY1 2

parametersZZ 
.ZZ 
AddZZ 
(ZZ 
newZZ 
SqlParameterZZ +
(ZZ+ ,
$strZZ, 6
,ZZ6 7
clienteZZ8 ?
)ZZ? @
)ZZ@ A
;ZZA B
table[[ 
=[[ 
ExecuteReader[[ !
([[! "
$str[[" B
)[[B C
;[[C D
return\\ 
table\\ 
;\\ 
}]] 	
public`` 
	DataTable`` *
ConsultarCotizacionesPorEstado`` 7
(``7 8
bool``8 <
estado``= C
)``C D
{aa 	
	DataTablebb 
tablebb 
=bb 
newbb !
	DataTablebb" +
(bb+ ,
)bb, -
;bb- .

parameterscc 
=cc 
newcc 
Listcc !
<cc! "
SqlParametercc" .
>cc. /
(cc/ 0
)cc0 1
;cc1 2

parametersdd 
.dd 
Adddd 
(dd 
newdd 
SqlParameterdd +
(dd+ ,
$strdd, 5
,dd5 6
estadodd7 =
)dd= >
)dd> ?
;dd? @
tableee 
=ee 
ExecuteReaderee !
(ee! "
$stree" A
)eeA B
;eeB C
returnff 
tableff 
;ff 
}gg 	
publicjj 
	DataTablejj (
ConsultarCotizacionDetalladajj 5
(jj5 6
intjj6 9
codigojj: @
)jj@ A
{kk 	
	DataTablell 
tablell 
=ll 
newll !
	DataTablell" +
(ll+ ,
)ll, -
;ll- .

parametersmm 
=mm 
newmm 
Listmm !
<mm! "
SqlParametermm" .
>mm. /
(mm/ 0
)mm0 1
;mm1 2

parametersnn 
.nn 
Addnn 
(nn 
newnn 
SqlParameternn +
(nn+ ,
$strnn, 5
,nn5 6
codigonn7 =
)nn= >
)nn> ?
;nn? @
tableoo 
=oo 
ExecuteReaderoo !
(oo! "
$stroo" B
)ooB C
;ooC D
returnpp 
tablepp 
;pp 
}qq 	
publictt 
	DataTablett (
ConsultarMetaDatosCotizaciontt 5
(tt5 6
inttt6 9
codigott: @
)tt@ A
{uu 	
	DataTablevv 
tablevv 
=vv 
newvv !
	DataTablevv" +
(vv+ ,
)vv, -
;vv- .

parametersww 
=ww 
newww 
Listww !
<ww! "
SqlParameterww" .
>ww. /
(ww/ 0
)ww0 1
;ww1 2

parametersxx 
.xx 
Addxx 
(xx 
newxx 
SqlParameterxx +
(xx+ ,
$strxx, 5
,xx5 6
codigoxx7 =
)xx= >
)xx> ?
;xx? @
tableyy 
=yy 
ExecuteReaderyy !
(yy! "
$stryy" B
)yyB C
;yyC D
returnzz 
tablezz 
;zz 
}{{ 	
}|| 
}}} �2
�C:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Datos\SqlServer\DatosSalidas.cs
	namespace 	
Datos
 
{ 
public		 

class		 
DatosSalidas		 
:		 
ExecuteCommandSql		  1
{

 
public 
	DataTable 
ObtenerCodigoSalida ,
(, -
)- .
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .
table 
= 
ExecuteReaderText %
(% &
$str& S
)S T
;T U
return 
table 
; 
} 	
public 
void 
RegistrarSalida #
(# $
DateTime$ ,
fecha- 2
)2 3
{ 	

parameters 
= 
new 
List !
<! "
SqlParameter" .
>. /
(/ 0
)0 1
;1 2

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, :
,: ;
fecha< A
)A B
)B C
;C D
ExecuteNonQuery 
( 
$str /
)/ 0
;0 1
} 	
public 
void 
EliminarSalida "
(" #
)# $
{ 	
ExecuteNonQuery 
( 
$str 4
)4 5
;5 6
} 	
public"" 
void"" 
MultiplesSalidas"" $
(""$ %
IEnumerable""% 0
<""0 1
DetallesSalida""1 ?
>""? @
detallesSalida""A O
)""O P
{## 	
var$$ 
table$$ 
=$$ 
new$$ 
	DataTable$$ %
($$% &
)$$& '
;$$' (
table%% 
.%% 
Columns%% 
.%% 
Add%% 
(%% 
$str%% -
,%%- .
typeof%%/ 5
(%%5 6
int%%6 9
)%%9 :
)%%: ;
;%%; <
table&& 
.&& 
Columns&& 
.&& 
Add&& 
(&& 
$str&& .
,&&. /
typeof&&0 6
(&&6 7
int&&7 :
)&&: ;
)&&; <
;&&< =
table'' 
.'' 
Columns'' 
.'' 
Add'' 
('' 
$str'' .
,''. /
typeof''0 6
(''6 7
int''7 :
)'': ;
)''; <
;''< =
table(( 
.(( 
Columns(( 
.(( 
Add(( 
((( 
$str(( /
,((/ 0
typeof((1 7
(((7 8
int((8 ;
)((; <
)((< =
;((= >
table)) 
.)) 
Columns)) 
.)) 
Add)) 
()) 
$str)) &
,))& '
typeof))( .
()). /
float))/ 4
)))4 5
)))5 6
;))6 7
table** 
.** 
Columns** 
.** 
Add** 
(** 
$str** (
,**( )
typeof*** 0
(**0 1
int**1 4
)**4 5
)**5 6
;**6 7
foreach,, 
(,, 
var,, 
itemDetalle,, $
in,,% '
detallesSalida,,( 6
),,6 7
{-- 
table.. 
... 
Rows.. 
... 
Add.. 
(.. 
new.. "
object..# )
[..) *
]..* +
{// 
itemDetalle00 
.00  
codigo_salida00  -
,00- .
itemDetalle11 
.11  
codigo_cliente11  .
,11. /
itemDetalle22 
.22  
codigo_usuario22  .
,22. /
itemDetalle33 
.33  
codigo_servicio33  /
,33/ 0
itemDetalle44 
.44  
precio44  &
,44& '
itemDetalle55 
.55  
cantidad55  (
}66 
)66 
;66 
}77 

parameters99 
=99 
new99 
List99 !
<99! "
SqlParameter99" .
>99. /
(99/ 0
)990 1
;991 2

parameters:: 
.:: 
Add:: 
(:: 
new:: 
SqlParameter:: +
(::+ ,
$str::, ;
,::; <
	SqlDbType::= F
.::F G
Int::G J
)::J K
)::K L
;::L M

parameters;; 
.;; 
Add;; 
(;; 
new;; 
SqlParameter;; +
(;;+ ,
$str;;, <
,;;< =
	SqlDbType;;> G
.;;G H
Int;;H K
);;K L
);;L M
;;;M N

parameters<< 
.<< 
Add<< 
(<< 
new<< 
SqlParameter<< +
(<<+ ,
$str<<, <
,<<< =
	SqlDbType<<> G
.<<G H
Int<<H K
)<<K L
)<<L M
;<<M N

parameters== 
.== 
Add== 
(== 
new== 
SqlParameter== +
(==+ ,
$str==, =
,=== >
	SqlDbType==? H
.==H I
Int==I L
)==L M
)==M N
;==N O

parameters>> 
.>> 
Add>> 
(>> 
new>> 
SqlParameter>> +
(>>+ ,
$str>>, 5
,>>5 6
	SqlDbType>>7 @
.>>@ A
Float>>A F
)>>F G
)>>G H
;>>H I

parameters?? 
.?? 
Add?? 
(?? 
new?? 
SqlParameter?? +
(??+ ,
$str??, 7
,??7 8
	SqlDbType??9 B
.??B C
Int??C F
)??F G
)??G H
;??H I
tryAA 
{BB #
ExecuteMultipleNonQueryCC '
(CC' (
$strCC( U
+CCV W
$strDD X
+DDY Z
$strEE ]
+EE^ _
$strFF )
,FF) *
tableFF+ 0
)FF0 1
;FF1 2
}GG 
catchHH 
{II 
EliminarSalidaJJ 
(JJ 
)JJ  
;JJ  !
throwKK 
;KK 
}LL 
}MM 	
}NN 
}OO �z
�C:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Datos\SqlServer\DatosServicios.cs
	namespace 	
Datos
 
{ 
public 

class 
DatosServicios 
:  !
ExecuteCommandSql" 3
{ 
public

 
void

 
RegistrarServicio

 %
(

% &
string

& ,
nombreServicio

- ;
,

; <
string

= C
descripcion

D O
,

O P
float

Q V
precio

W ]
,

] ^
bool

_ c
estado

d j
)

j k
{ 	

parameters 
= 
new 
List !
<! "
SqlParameter" .
>. /
(/ 0
)0 1
;1 2

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, >
,> ?
nombreServicio@ N
)N O
)O P
;P Q

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, :
,: ;
descripcion< G
)G H
)H I
;I J

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, 5
,5 6
precio7 =
)= >
)> ?
;? @

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, 5
,5 6
estado7 =
)= >
)> ?
;? @
ExecuteNonQuery 
( 
$str 0
)0 1
;1 2
} 	
public 
void %
RegistrarMaterialServicio -
(- .
int. 1
codigoMaterial2 @
,@ A
floatB G
cantidadH P
)P Q
{ 	

parameters 
= 
new 
List !
<! "
SqlParameter" .
>. /
(/ 0
)0 1
;1 2

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, =
,= >
codigoMaterial? M
)M N
)N O
;O P

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, 7
,7 8
cantidad9 A
)A B
)B C
;C D
ExecuteNonQuery 
( 
$str ;
); <
;< =
} 	
public 
void *
RegistrarNuevoMaterialServicio 2
(2 3
int3 6
codigoServicio7 E
,E F
intG J
codigoMaterialK Y
,Y Z
float[ `
cantidada i
)i j
{ 	

parameters   
=   
new   
List   !
<  ! "
SqlParameter  " .
>  . /
(  / 0
)  0 1
;  1 2

parameters!! 
.!! 
Add!! 
(!! 
new!! 
SqlParameter!! +
(!!+ ,
$str!!, =
,!!= >
codigoServicio!!? M
)!!M N
)!!N O
;!!O P

parameters"" 
."" 
Add"" 
("" 
new"" 
SqlParameter"" +
(""+ ,
$str"", =
,""= >
codigoMaterial""? M
)""M N
)""N O
;""O P

parameters## 
.## 
Add## 
(## 
new## 
SqlParameter## +
(##+ ,
$str##, 7
,##7 8
cantidad##9 A
)##A B
)##B C
;##C D
ExecuteNonQuery$$ 
($$ 
$str$$ @
)$$@ A
;$$A B
}%% 	
public(( 
void(( 
ActualizarServicio(( &
(((& '
int((' *
codigoServicio((+ 9
,((9 :
string((; A
nombreServicio((B P
,((P Q
float)) 
precio)) 
,)) 
string))  
descripcion))! ,
,)), -
bool)). 2
estado))3 9
)))9 :
{** 	

parameters++ 
=++ 
new++ 
List++ !
<++! "
SqlParameter++" .
>++. /
(++/ 0
)++0 1
;++1 2

parameters,, 
.,, 
Add,, 
(,, 
new,, 
SqlParameter,, +
(,,+ ,
$str,,, =
,,,= >
codigoServicio,,? M
),,M N
),,N O
;,,O P

parameters-- 
.-- 
Add-- 
(-- 
new-- 
SqlParameter-- +
(--+ ,
$str--, =
,--= >
nombreServicio--? M
)--M N
)--N O
;--O P

parameters.. 
... 
Add.. 
(.. 
new.. 
SqlParameter.. +
(..+ ,
$str.., 5
,..5 6
precio..7 =
)..= >
)..> ?
;..? @

parameters// 
.// 
Add// 
(// 
new// 
SqlParameter// +
(//+ ,
$str//, :
,//: ;
descripcion//< G
)//G H
)//H I
;//I J

parameters00 
.00 
Add00 
(00 
new00 
SqlParameter00 +
(00+ ,
$str00, 5
,005 6
estado007 =
)00= >
)00> ?
;00? @
ExecuteNonQuery11 
(11 
$str11 2
)112 3
;113 4
}22 	
public55 
void55 &
ActualizarMaterialServicio55 .
(55. /
int55/ 2
codigoServicio553 A
,55A B
int66 
codigoMaterial66 
,66 
int66  #
materialAnterior66$ 4
,664 5
int666 9
cantidad66: B
)66B C
{77 	

parameters88 
=88 
new88 
List88 !
<88! "
SqlParameter88" .
>88. /
(88/ 0
)880 1
;881 2

parameters99 
.99 
Add99 
(99 
new99 
SqlParameter99 +
(99+ ,
$str99, =
,99= >
codigoServicio99? M
)99M N
)99N O
;99O P

parameters:: 
.:: 
Add:: 
(:: 
new:: 
SqlParameter:: +
(::+ ,
$str::, =
,::= >
codigoMaterial::? M
)::M N
)::N O
;::O P

parameters;; 
.;; 
Add;; 
(;; 
new;; 
SqlParameter;; +
(;;+ ,
$str;;, ?
,;;? @
materialAnterior;;A Q
);;Q R
);;R S
;;;S T

parameters<< 
.<< 
Add<< 
(<< 
new<< 
SqlParameter<< +
(<<+ ,
$str<<, 7
,<<7 8
cantidad<<9 A
)<<A B
)<<B C
;<<C D
ExecuteNonQuery== 
(== 
$str== <
)==< =
;=== >
}>> 	
publicAA 
voidAA $
EliminarMaterialServicioAA ,
(AA, -
intAA- 0
codigoServicioAA1 ?
,AA? @
intAAA D
codigoMaterialAAE S
)AAS T
{BB 	

parametersCC 
=CC 
newCC 
ListCC !
<CC! "
SqlParameterCC" .
>CC. /
(CC/ 0
)CC0 1
;CC1 2

parametersDD 
.DD 
AddDD 
(DD 
newDD 
SqlParameterDD +
(DD+ ,
$strDD, =
,DD= >
codigoServicioDD? M
)DDM N
)DDN O
;DDO P

parametersEE 
.EE 
AddEE 
(EE 
newEE 
SqlParameterEE +
(EE+ ,
$strEE, =
,EE= >
codigoMaterialEE? M
)EEM N
)EEN O
;EEO P
ExecuteNonQueryFF 
(FF 
$strFF :
)FF: ;
;FF; <
}GG 	
publicJJ 
voidJJ 
EliminarServicioJJ $
(JJ$ %
intJJ% (
codigoServicioJJ) 7
)JJ7 8
{KK 	

parametersLL 
=LL 
newLL 
ListLL !
<LL! "
SqlParameterLL" .
>LL. /
(LL/ 0
)LL0 1
;LL1 2

parametersMM 
.MM 
AddMM 
(MM 
newMM 
SqlParameterMM +
(MM+ ,
$strMM, =
,MM= >
codigoServicioMM? M
)MMM N
)MMN O
;MMO P
ExecuteNonQueryNN 
(NN 
$strNN 0
)NN0 1
;NN1 2
}OO 	
publicRR 
voidRR "
EliminarServicioEstadoRR *
(RR* +
intRR+ .
codigoServicioRR/ =
)RR= >
{SS 	

parametersTT 
=TT 
newTT 
ListTT !
<TT! "
SqlParameterTT" .
>TT. /
(TT/ 0
)TT0 1
;TT1 2

parametersUU 
.UU 
AddUU 
(UU 
newUU 
SqlParameterUU +
(UU+ ,
$strUU, =
,UU= >
codigoServicioUU? M
)UUM N
)UUN O
;UUO P
ExecuteNonQueryVV 
(VV 
$strVV 6
)VV6 7
;VV7 8
}WW 	
publicZZ 
	DataTableZZ 
MostrarServiciosZZ )
(ZZ) *
)ZZ* +
{[[ 	
	DataTable\\ 
table\\ 
=\\ 
new\\ !
	DataTable\\" +
(\\+ ,
)\\, -
;\\- .
table]] 
=]] 
ExecuteReaderText]] %
(]]% &
$str]]& _
+]]` a
$str^^ f
+^^g h
$str__ >
)__> ?
;__? @
return`` 
table`` 
;`` 
}aa 	
publicdd 
	DataTabledd (
MostrarNombreCodigoServiciosdd 5
(dd5 6
)dd6 7
{ee 	
	DataTableff 
tableff 
=ff 
newff !
	DataTableff" +
(ff+ ,
)ff, -
;ff- .
tablegg 
=gg 
ExecuteReaderTextgg %
(gg% &
$strgg& f
)ggf g
;ggg h
returnhh 
tablehh 
;hh 
}ii 	
publicll 
	DataTablell  
BuscarPrecioServicioll -
(ll- .
intll. 1
codigoServicioll2 @
)ll@ A
{mm 	

parametersnn 
=nn 
newnn 
Listnn !
<nn! "
SqlParameternn" .
>nn. /
(nn/ 0
)nn0 1
;nn1 2

parametersoo 
.oo 
Addoo 
(oo 
newoo 
SqlParameteroo +
(oo+ ,
$stroo, =
,oo= >
codigoServiciooo? M
)ooM N
)ooN O
;ooO P
	DataTablepp 
tablepp 
=pp 
newpp !
	DataTablepp" +
(pp+ ,
)pp, -
;pp- .
tableqq 
=qq 
ExecuteReaderTextqq %
(qq% &
$strqq& c
)qqc d
;qqd e
returnrr 
tablerr 
;rr 
}ss 	
publicvv 
	DataTablevv &
MostrarMaterialesServiciosvv 3
(vv3 4
intvv4 7
codigoServiciovv8 F
)vvF G
{ww 	
	DataTablexx 
tablexx 
=xx 
newxx !
	DataTablexx" +
(xx+ ,
)xx, -
;xx- .

parametersyy 
=yy 
newyy 
Listyy !
<yy! "
SqlParameteryy" .
>yy. /
(yy/ 0
)yy0 1
;yy1 2

parameterszz 
.zz 
Addzz 
(zz 
newzz 
SqlParameterzz +
(zz+ ,
$strzz, =
,zz= >
codigoServiciozz? M
)zzM N
)zzN O
;zzO P
table{{ 
={{ 
ExecuteReader{{ !
({{! "
$str{{" @
){{@ A
;{{A B
return|| 
table|| 
;|| 
}}} 	
public
�� 
	DataTable
�� "
BuscarServicioCodigo
�� -
(
��- .
int
��. 1
codigoServicio
��2 @
)
��@ A
{
�� 	
	DataTable
�� 
table
�� 
=
�� 
new
�� !
	DataTable
��" +
(
��+ ,
)
��, -
;
��- .

parameters
�� 
=
�� 
new
�� 
List
�� !
<
��! "
SqlParameter
��" .
>
��. /
(
��/ 0
)
��0 1
;
��1 2

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 5
,
��5 6
codigoServicio
��7 E
)
��E F
)
��F G
;
��G H
table
�� 
=
�� 
ExecuteReader
�� !
(
��! "
$str
��" :
)
��: ;
;
��; <
return
�� 
table
�� 
;
�� 
}
�� 	
public
�� 
	DataTable
�� "
BuscarServicioNombre
�� -
(
��- .
string
��. 4
nombreServicio
��5 C
)
��C D
{
�� 	
	DataTable
�� 
table
�� 
=
�� 
new
�� !
	DataTable
��" +
(
��+ ,
)
��, -
;
��- .

parameters
�� 
=
�� 
new
�� 
List
�� !
<
��! "
SqlParameter
��" .
>
��. /
(
��/ 0
)
��0 1
;
��1 2

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, =
,
��= >
nombreServicio
��? M
)
��M N
)
��N O
;
��O P
table
�� 
=
�� 
ExecuteReader
�� !
(
��! "
$str
��" :
)
��: ;
;
��; <
return
�� 
table
�� 
;
�� 
}
�� 	
public
�� 
	DataTable
�� "
BuscarServicioEstado
�� -
(
��- .
bool
��. 2
estado
��3 9
)
��9 :
{
�� 	
	DataTable
�� 
table
�� 
=
�� 
new
�� !
	DataTable
��" +
(
��+ ,
)
��, -
;
��- .

parameters
�� 
=
�� 
new
�� 
List
�� !
<
��! "
SqlParameter
��" .
>
��. /
(
��/ 0
)
��0 1
;
��1 2

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 5
,
��5 6
estado
��7 =
)
��= >
)
��> ?
;
��? @
table
�� 
=
�� 
ExecuteReader
�� !
(
��! "
$str
��" :
)
��: ;
;
��; <
return
�� 
table
�� 
;
�� 
}
�� 	
}
�� 
}�� �Y
�C:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Datos\SqlServer\ExecuteCommandSql.cs
	namespace 	
Datos
 
{ 
public 

abstract 
class 
ExecuteCommandSql +
:, -
ConnectionSql. ;
{		 
	protected

 
List

 
<

 
SqlParameter

 #
>

# $

parameters

% /
;

/ 0
	protected 
int 
ExecuteNonQuery %
(% &
string& ,

commandSql- 7
)7 8
{ 	
using 
( 
var 
conexion 
=  !
GetConnection" /
(/ 0
)0 1
)1 2
{ 
conexion 
. 
Open 
( 
) 
;  
using 
( 
var 
comando "
=# $
new% (

SqlCommand) 3
(3 4

commandSql4 >
,> ?
conexion@ H
)H I
)I J
{ 
comando 
. 
CommandType '
=( )
CommandType* 5
.5 6
StoredProcedure6 E
;E F
if 
( 

parameters "
!=# %
null& *
)* +
{ 
foreach 
(  !
SqlParameter! -
item. 2
in3 5

parameters6 @
)@ A
{ 
comando #
.# $

Parameters$ .
.. /
Add/ 2
(2 3
item3 7
)7 8
;8 9
} 
} 
int   
result   
=    
comando  ! (
.  ( )
ExecuteNonQuery  ) 8
(  8 9
)  9 :
;  : ;

parameters!! 
.!! 
Clear!! $
(!!$ %
)!!% &
;!!& '
return"" 
result"" !
;""! "
}## 
}$$ 
}%% 	
	protected(( 
int(( 
ExecuteNonQueryText(( )
((() *
string((* 0

commandSql((1 ;
)((; <
{)) 	
using** 
(** 
var** 
conexion** 
=**  !
GetConnection**" /
(**/ 0
)**0 1
)**1 2
{++ 
conexion,, 
.,, 
Open,, 
(,, 
),, 
;,,  
using.. 
(.. 
var.. 
comando.. "
=..# $
new..% (

SqlCommand..) 3
(..3 4

commandSql..4 >
,..> ?
conexion..@ H
)..H I
)..I J
{// 
comando00 
.00 
CommandType00 '
=00( )
CommandType00* 5
.005 6
Text006 :
;00: ;
if33 
(33 

parameters33 "
!=33# %
null33& *
)33* +
{44 
foreach55 
(55  !
SqlParameter55! -
item55. 2
in553 5

parameters556 @
)55@ A
{66 
comando77 #
.77# $

Parameters77$ .
.77. /
Add77/ 2
(772 3
item773 7
)777 8
;778 9
}88 
}99 
int;; 
result;; 
=;;  
comando;;! (
.;;( )
ExecuteNonQuery;;) 8
(;;8 9
);;9 :
;;;: ;

parameters<< 
.<< 
Clear<< $
(<<$ %
)<<% &
;<<& '
return== 
result== !
;==! "
}>> 
}?? 
}@@ 	
	protectedCC 
voidCC #
ExecuteMultipleNonQueryCC .
(CC. /
stringCC/ 5

commandSqlCC6 @
,CC@ A
	DataTableCCB K
tableCCL Q
)CCQ R
{DD 	
usingEE 
(EE 
varEE 
conexionEE 
=EE  !
GetConnectionEE" /
(EE/ 0
)EE0 1
)EE1 2
{FF 
conexionGG 
.GG 
OpenGG 
(GG 
)GG 
;GG  
usingII 
(II 
SqlTransactionII %
transactionII& 1
=II2 3
conexionII4 <
.II< =
BeginTransactionII= M
(IIM N
)IIN O
)IIO P
{JJ 
usingKK 
(KK 
varKK 
comandoKK &
=KK' (
newKK) ,

SqlCommandKK- 7
(KK7 8

commandSqlKK8 B
,KKB C
conexionKKD L
)KKL M
)KKM N
{LL 
comandoMM 
.MM  
CommandTypeMM  +
=MM, -
CommandTypeMM. 9
.MM9 :
TextMM: >
;MM> ?
comandoNN 
.NN  
TransactionNN  +
=NN, -
transactionNN. 9
;NN9 :
foreachPP 
(PP  !
SqlParameterPP! -
itemPP. 2
inPP3 5

parametersPP6 @
)PP@ A
{QQ 
comandoRR #
.RR# $

ParametersRR$ .
.RR. /
AddRR/ 2
(RR2 3
itemRR3 7
)RR7 8
;RR8 9
}SS 
tryUU 
{VV 
forWW 
(WW  !
intWW! $
filaWW% )
=WW* +
$numWW, -
;WW- .
filaWW/ 3
<WW4 5
tableWW6 ;
.WW; <
RowsWW< @
.WW@ A
CountWWA F
;WWF G
filaWWH L
++WWL N
)WWN O
{XX 
forYY  #
(YY$ %
intYY% (
columnaYY) 0
=YY1 2
$numYY3 4
;YY4 5
columnaYY6 =
<YY> ?
tableYY@ E
.YYE F
ColumnsYYF M
.YYM N
CountYYN S
;YYS T
columnaYYU \
++YY\ ^
)YY^ _
{ZZ  !

parameters[[$ .
[[[. /
columna[[/ 6
][[6 7
.[[7 8
Value[[8 =
=[[> ?
table[[@ E
.[[E F
Rows[[F J
[[[J K
fila[[K O
][[O P
[[[P Q
columna[[Q X
][[X Y
;[[Y Z
}\\  !
comando^^  '
.^^' (
ExecuteNonQuery^^( 7
(^^7 8
)^^8 9
;^^9 :
}__ 
transactionaa '
.aa' (
Commitaa( .
(aa. /
)aa/ 0
;aa0 1

parametersbb &
.bb& '
Clearbb' ,
(bb, -
)bb- .
;bb. /
}cc 
catchdd 
(dd 
	Exceptiondd (
)dd( )
{ee 
transactionff '
.ff' (
Rollbackff( 0
(ff0 1
)ff1 2
;ff2 3

parametersgg &
.gg& '
Cleargg' ,
(gg, -
)gg- .
;gg. /
throwhh !
;hh! "
}ii 
}jj 
}kk 
}ll 
}mm 	
	protectedpp 
	DataTablepp 
ExecuteReaderpp )
(pp) *
stringpp* 0

commandSqlpp1 ;
)pp; <
{qq 	
	DataTablerr 
tablerr 
=rr 
newrr !
	DataTablerr" +
(rr+ ,
)rr, -
;rr- .
usingtt 
(tt 
vartt 
conexiontt 
=tt  !
GetConnectiontt" /
(tt/ 0
)tt0 1
)tt1 2
{uu 
conexionvv 
.vv 
Openvv 
(vv 
)vv 
;vv  
usingxx 
(xx 
varxx 
comandoxx "
=xx# $
newxx% (

SqlCommandxx) 3
(xx3 4

commandSqlxx4 >
,xx> ?
conexionxx@ H
)xxH I
)xxI J
{yy 
comandozz 
.zz 
CommandTypezz '
=zz( )
CommandTypezz* 5
.zz5 6
StoredProcedurezz6 E
;zzE F
if}} 
(}} 

parameters}} "
!=}}# %
null}}& *
)}}* +
foreach~~ 
(~~  !
SqlParameter~~! -
item~~. 2
in~~3 5

parameters~~6 @
)~~@ A
comando #
.# $

Parameters$ .
.. /
Add/ 2
(2 3
item3 7
)7 8
;8 9
using
�� 
(
�� 
var
�� 
Reader
�� %
=
��& '
comando
��( /
.
��/ 0
ExecuteReader
��0 =
(
��= >
)
��> ?
)
��? @
{
�� 
table
�� 
.
�� 
Load
�� "
(
��" #
Reader
��# )
)
��) *
;
��* +
if
�� 
(
�� 

parameters
�� &
!=
��' )
null
��* .
)
��. /

parameters
�� &
.
��& '
Clear
��' ,
(
��, -
)
��- .
;
��. /
return
�� 
table
�� $
;
��$ %
}
�� 
}
�� 
}
�� 
}
�� 	
	protected
�� 
	DataTable
�� 
ExecuteReaderText
�� -
(
��- .
string
��. 4

commandSql
��5 ?
)
��? @
{
�� 	
	DataTable
�� 
table
�� 
=
�� 
new
�� !
	DataTable
��" +
(
��+ ,
)
��, -
;
��- .
using
�� 
(
�� 
var
�� 
conexion
�� 
=
��  !
GetConnection
��" /
(
��/ 0
)
��0 1
)
��1 2
{
�� 
conexion
�� 
.
�� 
Open
�� 
(
�� 
)
�� 
;
��  
using
�� 
(
�� 
var
�� 
comando
�� "
=
��# $
new
��% (

SqlCommand
��) 3
(
��3 4

commandSql
��4 >
,
��> ?
conexion
��@ H
)
��H I
)
��I J
{
�� 
comando
�� 
.
�� 
CommandType
�� '
=
��( )
CommandType
��* 5
.
��5 6
Text
��6 :
;
��: ;
if
�� 
(
�� 

parameters
�� "
!=
��# %
null
��& *
)
��* +
foreach
�� 
(
��  !
SqlParameter
��! -
item
��. 2
in
��3 5

parameters
��6 @
)
��@ A
comando
�� #
.
��# $

Parameters
��$ .
.
��. /
Add
��/ 2
(
��2 3
item
��3 7
)
��7 8
;
��8 9
using
�� 
(
�� 
var
�� 
Reader
�� %
=
��& '
comando
��( /
.
��/ 0
ExecuteReader
��0 =
(
��= >
)
��> ?
)
��? @
{
�� 
table
�� 
.
�� 
Load
�� "
(
��" #
Reader
��# )
)
��) *
;
��* +
if
�� 
(
�� 

parameters
�� &
!=
��' )
null
��* .
)
��. /

parameters
�� &
.
��& '
Clear
��' ,
(
��, -
)
��- .
;
��. /
return
�� 
table
�� $
;
��$ %
}
�� 
}
�� 
}
�� 
}
�� 	
}
�� 
}�� �
�C:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Datos\SqlServer\ConnectionSql.cs
	namespace 	
Datos
 
{ 
public 

abstract 
class 
ConnectionSql '
{ 
private 
readonly 
string 
cadenaConexion  .
;. /
public

 
ConnectionSql

 
(

 
)

 
{ 	
cadenaConexion 
=  
ConfigurationManager 1
.1 2
ConnectionStrings2 C
[C D
$strD g
]g h
.h i
ToStringi q
(q r
)r s
;s t
} 	
	protected 
SqlConnection 
GetConnection  -
(- .
). /
{ 	
return 
new 
SqlConnection $
($ %
cadenaConexion% 3
)3 4
;4 5
} 	
} 
} ܅
�C:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Datos\SqlServer\DatosUsuarios.cs
	namespace 	
Datos
 
{ 
public		 

class		 
DatosUsuarios		 
:		  
ExecuteCommandSql		! 2
{

 
public 
bool 
LoginUsuario  
(  !
string! '
nombre( .
,. /
string0 6
password7 ?
)? @
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .

parameters 
= 
new 
List !
<! "
SqlParameter" .
>. /
(/ 0
)0 1
;1 2

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, =
,= >
nombre? E
)E F
)F G
;G H

parameters 
. 
Add 
( 
new 
SqlParameter +
(+ ,
$str, 7
,7 8
password9 A
)A B
)B C
;C D
table 
= 
ExecuteReader !
(! "
$str" 2
)2 3
;3 4
if 
( 
table 
. 
Rows 
. 
Count  
>! "
$num# $
)$ %
{ 
foreach 
( 
DataRow  
fila! %
in& (
table) .
.. /
Rows/ 3
)3 4
{ 
UsuarioLoginCache %
.% &
Codigo_usuario& 4
=5 6
Convert7 >
.> ?
ToInt32? F
(F G
filaG K
[K L
$numL M
]M N
)N O
;O P
UsuarioLoginCache %
.% &
Codigo_tipo_usuario& 9
=: ;
Convert< C
.C D
ToInt32D K
(K L
filaL P
[P Q
$numQ R
]R S
)S T
;T U
UsuarioLoginCache %
.% &
Tipo_usuario& 2
=3 4
fila5 9
[9 :
$num: ;
]; <
.< =
ToString= E
(E F
)F G
;G H
UsuarioLoginCache %
.% &
Nombre_usuario& 4
=5 6
fila7 ;
[; <
$num< =
]= >
.> ?
ToString? G
(G H
)H I
;I J
UsuarioLoginCache %
.% &
Nombre& ,
=- .
fila/ 3
[3 4
$num4 5
]5 6
.6 7
ToString7 ?
(? @
)@ A
;A B
UsuarioLoginCache %
.% &
Email& +
=, -
fila. 2
[2 3
$num3 4
]4 5
.5 6
ToString6 >
(> ?
)? @
;@ A
UsuarioLoginCache %
.% &
Password& .
=/ 0
fila1 5
[5 6
$num6 7
]7 8
.8 9
ToString9 A
(A B
)B C
;C D
if!! 
(!! 
fila!! 
[!! 
$num!! 
]!! 
.!!  
ToString!!  (
(!!( )
)!!) *
==!!+ -
$str!!. 6
)!!6 7
UsuarioLoginCache"" )
."") *
Estado""* 0
=""1 2
true""3 7
;""7 8
else## 
UsuarioLoginCache$$ )
.$$) *
Estado$$* 0
=$$1 2
false$$3 8
;$$8 9
}%% 
return'' 
true'' 
;'' 
}(( 
else)) 
{** 
return++ 
false++ 
;++ 
},, 
}-- 	
public00 
string00 
RecuperarPassword00 '
(00' (
string00( .
usuarioSolicitante00/ A
)00A B
{11 	
	DataTable22 
table22 
=22 
new22 !
	DataTable22" +
(22+ ,
)22, -
;22- .

parameters33 
=33 
new33 
List33 !
<33! "
SqlParameter33" .
>33. /
(33/ 0
)330 1
;331 2

parameters44 
.44 
Add44 
(44 
new44 
SqlParameter44 +
(44+ ,
$str44, 6
,446 7
usuarioSolicitante448 J
)44J K
)44K L
;44L M

parameters55 
.55 
Add55 
(55 
new55 
SqlParameter55 +
(55+ ,
$str55, 5
,555 6
usuarioSolicitante557 I
)55I J
)55J K
;55K L
table77 
=77 
ExecuteReaderText77 %
(77% &
$str77& ]
+77^ _
$str88 R
)88R S
;88S T
if:: 
(:: 
table:: 
.:: 
Rows:: 
.:: 
Count::  
>::! "
$num::# $
)::$ %
{;; 
string<< 
nombreUsuario<< $
=<<% &
$str<<' )
;<<) *
string== 
nombre== 
=== 
$str==  "
;==" #
string>> 
correo>> 
=>> 
$str>>  "
;>>" #
string?? 
password?? 
=??  !
$str??" $
;??$ %
foreachAA 
(AA 
DataRowAA  
filaAA! %
inAA& (
tableAA) .
.AA. /
RowsAA/ 3
)AA3 4
{BB 
nombreUsuarioCC !
=CC" #
filaCC$ (
[CC( )
$numCC) *
]CC* +
.CC+ ,
ToStringCC, 4
(CC4 5
)CC5 6
;CC6 7
nombreDD 
=DD 
filaDD !
[DD! "
$numDD" #
]DD# $
.DD$ %
ToStringDD% -
(DD- .
)DD. /
;DD/ 0
correoEE 
=EE 
filaEE !
[EE! "
$numEE" #
]EE# $
.EE$ %
ToStringEE% -
(EE- .
)EE. /
;EE/ 0
passwordFF 
=FF 
filaFF #
[FF# $
$numFF$ %
]FF% &
.FF& '
ToStringFF' /
(FF/ 0
)FF0 1
;FF1 2
varHH 
servicioCorreoHH &
=HH' (
newHH) ,
ServiciosCorreoHH- <
.HH< =
SoporteCorreoHH= J
(HHJ K
)HHK L
;HHL M
servicioCorreoJJ "
.JJ" #
enviarCorreoJJ# /
(JJ/ 0
asuntoKK 
:KK 
$strKK  I
,KKI J
cuerpoLL 
:LL 
$strLL  (
+LL) *
nombreLL+ 1
+LL2 3
$strLL4 d
+LLe f
$strMM 3
+MM4 5
passwordMM6 >
+MM? @
$strMMA F
+MMG H
$strNN m
,NNm n
correoDestinatarioOO *
:OO* +
newOO, /
ListOO0 4
<OO4 5
stringOO5 ;
>OO; <
{OO= >
correoOO? E
}OOF G
)PP 
;PP 
}QQ 
returnSS 
$strSS 
+SS  !
nombreSS" (
+SS) *
$strSS+ X
+SSY Z
$strTT ?
+TT@ A
correoTTB H
+TTI J
$strTTK P
+TTQ R
$strUU i
;UUi j
}VV 
elseWW 
{XX 
returnYY 
$strYY ]
;YY] ^
}ZZ 
}[[ 	
public^^ 
	DataTable^^ 
	ShowUsers^^ "
(^^" #
)^^# $
{__ 	
	DataTable`` 
table`` 
=`` 
new`` !
	DataTable``" +
(``+ ,
)``, -
;``- .
tableaa 
=aa 
ExecuteReaderaa !
(aa! "
$straa" 5
)aa5 6
;aa6 7
returnbb 
tablebb 
;bb 
}cc 	
publicff 
	DataTableff 
TiposUsuariosff &
(ff& '
)ff' (
{gg 	
	DataTablehh 
tablehh 
=hh 
newhh !
	DataTablehh" +
(hh+ ,
)hh, -
;hh- .
tableii 
=ii 
ExecuteReaderTextii %
(ii% &
$strii& V
)iiV W
;iiW X
returnjj 
tablejj 
;jj 
}kk 	
publicnn 
	DataTablenn  
MostrarUsuarioCodigonn -
(nn- .
intnn. 1
codigonn2 8
)nn8 9
{oo 	
	DataTablepp 
tablepp 
=pp 
newpp !
	DataTablepp" +
(pp+ ,
)pp, -
;pp- .

parametersqq 
=qq 
newqq 
Listqq !
<qq! "
SqlParameterqq" .
>qq. /
(qq/ 0
)qq0 1
;qq1 2

parametersrr 
.rr 
Addrr 
(rr 
newrr 
SqlParameterrr +
(rr+ ,
$strrr, 5
,rr5 6
codigorr7 =
)rr= >
)rr> ?
;rr? @
tabless 
=ss 
ExecuteReaderss !
(ss! "
$strss" ;
)ss; <
;ss< =
returntt 
tablett 
;tt 
}uu 	
publicxx 
	DataTablexx  
MostrarUsuarioNombrexx -
(xx- .
stringxx. 4
nombreUsuarioxx5 B
)xxB C
{yy 	
	DataTablezz 
tablezz 
=zz 
newzz !
	DataTablezz" +
(zz+ ,
)zz, -
;zz- .

parameters{{ 
={{ 
new{{ 
List{{ !
<{{! "
SqlParameter{{" .
>{{. /
({{/ 0
){{0 1
;{{1 2

parameters|| 
.|| 
Add|| 
(|| 
new|| 
SqlParameter|| +
(||+ ,
$str||, <
,||< =
nombreUsuario||> K
)||K L
)||L M
;||M N
table}} 
=}} 
ExecuteReader}} !
(}}! "
$str}}" ;
)}}; <
;}}< =
return~~ 
table~~ 
;~~ 
} 	
public
�� 
	DataTable
�� "
MostrarUsuarioEstado
�� -
(
��- .
bool
��. 2
estado
��3 9
)
��9 :
{
�� 	
	DataTable
�� 
table
�� 
=
�� 
new
�� !
	DataTable
��" +
(
��+ ,
)
��, -
;
��- .

parameters
�� 
=
�� 
new
�� 
List
�� !
<
��! "
SqlParameter
��" .
>
��. /
(
��/ 0
)
��0 1
;
��1 2

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 5
,
��5 6
estado
��7 =
)
��= >
)
��> ?
;
��? @
table
�� 
=
�� 
ExecuteReader
�� !
(
��! "
$str
��" :
)
��: ;
;
��; <
return
�� 
table
�� 
;
�� 
}
�� 	
public
�� 
void
�� 
RegistrarUsuario
�� $
(
��$ %
int
��% ( 
codigo_TipoUsuario
��) ;
,
��; <
string
��= C
nombre_usuario
��D R
,
��R S
string
��T Z
nombre
��[ a
,
��a b
string
�� 
password
�� 
,
�� 
string
�� #
email
��$ )
)
��) *
{
�� 	

parameters
�� 
=
�� 
new
�� 
List
�� !
<
��! "
SqlParameter
��" .
>
��. /
(
��/ 0
)
��0 1
;
��1 2

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, A
,
��A B 
codigo_TipoUsuario
��C U
)
��U V
)
��V W
;
��W X

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, <
,
��< =
nombre_usuario
��> L
)
��L M
)
��M N
;
��N O

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 5
,
��5 6
nombre
��7 =
)
��= >
)
��> ?
;
��? @

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 7
,
��7 8
password
��9 A
)
��A B
)
��B C
;
��C D

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 4
,
��4 5
email
��6 ;
)
��; <
)
��< =
;
��= >
ExecuteNonQuery
�� 
(
�� 
$str
�� /
)
��/ 0
;
��0 1
}
�� 	
public
�� 
void
�� 
ActualizarUsuario
�� %
(
��% &
int
��& ) 
codigo_tipoUsuario
��* <
,
��< =
string
��> D
nombre_usuario
��E S
,
��S T
string
��U [
nombre
��\ b
,
��b c
string
�� 
password
�� 
,
�� 
string
�� #
email
��$ )
,
��) *
bool
��+ /
estado
��0 6
,
��6 7
int
��8 ;
codigoUsuario
��< I
)
��I J
{
�� 	

parameters
�� 
=
�� 
new
�� 
List
�� !
<
��! "
SqlParameter
��" .
>
��. /
(
��/ 0
)
��0 1
;
��1 2

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, A
,
��A B 
codigo_tipoUsuario
��C U
)
��U V
)
��V W
;
��W X

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, <
,
��< =
nombre_usuario
��> L
)
��L M
)
��M N
;
��N O

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 5
,
��5 6
nombre
��7 =
)
��= >
)
��> ?
;
��? @

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 7
,
��7 8
password
��9 A
)
��A B
)
��B C
;
��C D

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 4
,
��4 5
email
��6 ;
)
��; <
)
��< =
;
��= >

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 5
,
��5 6
estado
��7 =
)
��= >
)
��> ?
;
��? @

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, 5
,
��5 6
codigoUsuario
��7 D
)
��D E
)
��E F
;
��F G
ExecuteNonQuery
�� 
(
�� 
$str
�� 1
)
��1 2
;
��2 3
}
�� 	
public
�� 
void
�� 
EliminarUsuario
�� #
(
��# $
int
��$ '
codigoUsuario
��( 5
)
��5 6
{
�� 	

parameters
�� 
=
�� 
new
�� 
List
�� !
<
��! "
SqlParameter
��" .
>
��. /
(
��/ 0
)
��0 1
;
��1 2

parameters
�� 
.
�� 
Add
�� 
(
�� 
new
�� 
SqlParameter
�� +
(
��+ ,
$str
��, <
,
��< =
codigoUsuario
��> K
)
��K L
)
��L M
;
��M N
ExecuteNonQuery
�� 
(
�� 
$str
�� /
)
��/ 0
;
��0 1
}
�� 	
}
�� 
}�� �
�C:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Datos\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 

AssemblyTitle 
( 
$str  
)  !
]! "
[ 
assembly 	
:	 

AssemblyDescription 
( 
$str !
)! "
]" #
[		 
assembly		 	
:			 
!
AssemblyConfiguration		  
(		  !
$str		! #
)		# $
]		$ %
[

 
assembly

 	
:

	 

AssemblyCompany

 
(

 
$str

 
)

 
]

 
[ 
assembly 	
:	 

AssemblyProduct 
( 
$str "
)" #
]# $
[ 
assembly 	
:	 

AssemblyCopyright 
( 
$str 0
)0 1
]1 2
[ 
assembly 	
:	 

AssemblyTrademark 
( 
$str 
)  
]  !
[ 
assembly 	
:	 

AssemblyCulture 
( 
$str 
) 
] 
[ 
assembly 	
:	 


ComVisible 
( 
false 
) 
] 
[ 
assembly 	
:	 

Guid 
( 
$str 6
)6 7
]7 8
["" 
assembly"" 	
:""	 

AssemblyVersion"" 
("" 
$str"" $
)""$ %
]""% &
[## 
assembly## 	
:##	 

AssemblyFileVersion## 
(## 
$str## (
)##( )
]##) *