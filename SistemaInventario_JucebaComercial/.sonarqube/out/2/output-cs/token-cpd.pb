è(
äC:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Dominio\DominioCliente.cs
	namespace 	
Dominio
 
{ 
public 

class 
DominioCliente 
{ 
DatosClientes		 
cliente		 
=		 
new		  #
DatosClientes		$ 1
(		1 2
)		2 3
;		3 4
public 
	DataTable 
ShowCostumers &
(& '
)' (
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
= 
cliente 
. 
MostrarClientes +
(+ ,
), -
;- .
return 
table 
; 
} 	
public 
	DataTable  
ShowCustumerNameCode -
(- .
). /
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .
table 
= 
cliente 
. '
MostrarNombreCodigoClientes 7
(7 8
)8 9
;9 :
return 
table 
; 
} 	
public 
	DataTable 
ShowCostumerByCode +
(+ ,
String, 2
codigoCliente3 @
)@ A
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .
table 
= 
cliente 
.  
MostrarClienteCodigo 0
(0 1
Convert1 8
.8 9
ToInt329 @
(@ A
codigoClienteA N
)N O
)O P
;P Q
return   
table   
;   
}!! 	
public$$ 
	DataTable$$ 
ShowCostumersByName$$ ,
($$, -
string$$- 3
nombreCliente$$4 A
)$$A B
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
='' 
cliente'' 
.''  
MostrarClienteNombre'' 0
(''0 1
nombreCliente''1 >
)''> ?
;''? @
return(( 
table(( 
;(( 
})) 	
public,, 
	DataTable,, !
ShowCostumersByStatus,, .
(,,. /
bool,,/ 3
estado,,4 :
),,: ;
{-- 	
	DataTable.. 
table.. 
=.. 
new.. !
	DataTable.." +
(..+ ,
).., -
;..- .
table// 
=// 
cliente// 
.//  
MostrarClienteEstado// 0
(//0 1
estado//1 7
)//7 8
;//8 9
return00 
table00 
;00 
}11 	
public44 
void44 
RegisterCostumer44 $
(44$ %
string44% +
telefono44, 4
,444 5
string446 <
codigoDireccion44= L
,44L M
string44N T
nombreCliente44U b
)44b c
{55 	
cliente66 
.66 
InsertarCliente66 #
(66# $
telefono66$ ,
,66, -
Convert66. 5
.665 6
ToInt32666 =
(66= >
codigoDireccion66> M
)66M N
,66N O
nombreCliente66P ]
)66] ^
;66^ _
}77 	
public:: 
void:: 
UpdateCostumer:: "
(::" #
string::# )
telefono::* 2
,::2 3
string::4 :
telefonoViejo::; H
,::H I
string::J P
codigoDireccion::Q `
,::` a
string::b h
nombreCliente::i v
,::v w
string;; 
codigoCliente;;  
,;;  !
bool;;" &
estado;;' -
);;- .
{<< 	
cliente== 
.== 
ActualizarCliente== %
(==% &
telefono==& .
,==. /
telefonoViejo==0 =
,=== >
Convert==? F
.==F G
ToInt32==G N
(==N O
codigoDireccion==O ^
)==^ _
,==_ `
nombreCliente==a n
,==n o
Convert==p w
.==w x
ToInt32==x 
(	== Ä
codigoCliente
==Ä ç
)
==ç é
,
==é è
estado
==ê ñ
)
==ñ ó
;
==ó ò
}>> 	
publicAA 
voidAA 
DeleteCostumerAA "
(AA" #
stringAA# )
codigoAA* 0
)AA0 1
{BB 	
clienteCC 
.CC 
EliminarClienteCC #
(CC# $
ConvertCC$ +
.CC+ ,
ToInt32CC, 3
(CC3 4
codigoCC4 :
)CC: ;
)CC; <
;CC< =
}DD 	
}EE 
}FF ≠>
èC:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Dominio\DominioCotizaciones.cs
	namespace 	
Dominio
 
{ 
public 

class 
DominioCotizaciones $
{ 
DatosCotizaciones		 
cotizar		 !
=		" #
new		$ '
DatosCotizaciones		( 9
(		9 :
)		: ;
;		; <
public 
void 
RegisterQuote !
(! "
DateTime" *
fechaCotizacion+ :
,: ;
string< B
descripcionC N
)N O
{ 	
cotizar 
. 
RegistrarCotizacion '
(' (
fechaCotizacion( 7
,7 8
descripcion9 D
)D E
;E F
} 	
public 
void  
RegisterDetailsQuote (
(( )
string) /
codigoUsuario0 =
,= >
string? E
codigoServicioF T
,T U
stringV \
codigoCliente] j
,j k
string 
cantidad 
, 
string #
precio$ *
)* +
{ 	
cotizar 
. '
RegistrarDetallesCotizacion /
(/ 0
Convert0 7
.7 8
ToInt328 ?
(? @
codigoUsuario@ M
)M N
,N O
Convert 
. 
ToInt32 
(  
codigoServicio  .
). /
,/ 0
Convert1 8
.8 9
ToInt329 @
(@ A
codigoClienteA N
)N O
,O P
Convert 
. 
ToInt32 
(  
cantidad  (
)( )
,) *
float+ 0
.0 1
Parse1 6
(6 7
precio7 =
)= >
)> ?
;? @
} 	
public 
void #
RegisterDetailsQuoteNew +
(+ ,
string, 2
codigoCotizacion3 C
,C D
stringE K
codigoUsuarioL Y
,Y Z
string[ a
serviciob j
,j k
stringl r
codigoCliente	s Ä
,
Ä Å
string 
cantidad 
, 
string #
precio$ *
)* +
{ 	
cotizar 
. -
!RegistrarNuevosDetallesCotizacion 5
(5 6
Convert6 =
.= >
ToInt32> E
(E F
codigoCotizacionF V
)V W
,W X
Convert 
. 
ToInt32 
(  
codigoUsuario  -
)- .
,. /
servicio0 8
,8 9
Convert   
.   
ToInt32   
(    
codigoCliente    -
)  - .
,  . /
Convert  0 7
.  7 8
ToInt32  8 ?
(  ? @
cantidad  @ H
)  H I
,  I J
float  K P
.  P Q
Parse  Q V
(  V W
precio  W ]
)  ] ^
)  ^ _
;  _ `
}!! 	
public$$ 
void$$ 
UpdateQuote$$ 
($$  
string$$  &
codigoCotizacion$$' 7
,$$7 8
DateTime$$9 A
fecha$$B G
,$$G H
string$$I O
descripcion$$P [
)$$[ \
{%% 	
cotizar&& 
.&& 
EditarCotizacion&& $
(&&$ %
Convert&&% ,
.&&, -
ToInt32&&- 4
(&&4 5
codigoCotizacion&&5 E
)&&E F
,&&F G
fecha&&H M
,&&M N
descripcion&&O Z
)&&Z [
;&&[ \
}'' 	
public** 
void** 
UpdateDetailsQuote** &
(**& '
string**' -#
codigoDetalleCotizacion**. E
,**E F
string**G M
servicio**N V
,**V W
string**X ^
codigoCliente**_ l
,**l m
string**n t
codigoUsuario	**u Ç
,
**Ç É
string
**Ñ ä
precio
**ã ë
,
**ë í
string
**ì ô
cantidad
**ö ¢
)
**¢ £
{++ 	
cotizar,, 
.,, #
EditarDetallesCotizaion,, +
(,,+ ,
Convert,,, 3
.,,3 4
ToInt32,,4 ;
(,,; <#
codigoDetalleCotizacion,,< S
),,S T
,,,T U
servicio--, 4
,--4 5
Convert.., 3
...3 4
ToInt32..4 ;
(..; <
codigoCliente..< I
)..I J
,..J K
Convert//, 3
.//3 4
ToInt32//4 ;
(//; <
codigoUsuario//< I
)//I J
,//J K
float00, 1
.001 2
Parse002 7
(007 8
precio008 >
)00> ?
,00? @
Convert11, 3
.113 4
ToInt32114 ;
(11; <
cantidad11< D
)11D E
)11E F
;11F G
}22 	
public55 
	DataTable55 
GetQuoteCode55 %
(55% &
)55& '
{66 	
	DataTable77 
table77 
=77 
new77 !
	DataTable77" +
(77+ ,
)77, -
;77- .
table88 
=88 
cotizar88 
.88 #
ObtenerCodigoCotizacion88 3
(883 4
)884 5
;885 6
return99 
table99 
;99 
}:: 	
public== 
	DataTable==  
GetDetailsQuoteCodes== -
(==- .
string==. 4
codigoCotizacion==5 E
)==E F
{>> 	
	DataTable?? 
table?? 
=?? 
new?? !
	DataTable??" +
(??+ ,
)??, -
;??- .
table@@ 
=@@ 
cotizar@@ 
.@@ .
"ObtenenerDetallesCotizacionCodigos@@ >
(@@> ?
Convert@@? F
.@@F G
ToInt32@@G N
(@@N O
codigoCotizacion@@O _
)@@_ `
)@@` a
;@@a b
returnAA 
tableAA 
;AA 
}BB 	
publicEE 
voidEE 
ApproveQuoteEE  
(EE  !
stringEE! '
codigoEE( .
,EE. /
boolEE0 4
estadoEE5 ;
)EE; <
{FF 	
cotizarGG 
.GG 
AprobarCotizacionGG %
(GG% &
ConvertGG& -
.GG- .
ToInt32GG. 5
(GG5 6
codigoGG6 <
)GG< =
,GG= >
estadoGG? E
)GGE F
;GGF G
}HH 	
publicKK 
voidKK 
DeleteQuoteKK 
(KK  
stringKK  &
codigoKK' -
)KK- .
{LL 	
cotizarMM 
.MM 
EliminarCotizacionMM &
(MM& '
ConvertMM' .
.MM. /
ToInt32MM/ 6
(MM6 7
codigoMM7 =
)MM= >
)MM> ?
;MM? @
}NN 	
publicQQ 
voidQQ 
DeleteDetailsQuoteQQ &
(QQ& '
stringQQ' -
codigoQQ. 4
)QQ4 5
{RR 	
cotizarSS 
.SS &
EliminarDetallesCotizacionSS .
(SS. /
ConvertSS/ 6
.SS6 7
ToInt32SS7 >
(SS> ?
codigoSS? E
)SSE F
)SSF G
;SSG H
}TT 	
publicWW 
voidWW $
DeleteDetailsQuoteByCodeWW ,
(WW, -
stringWW- 3
codigoWW4 :
)WW: ;
{XX 	
cotizarYY 
.YY /
#EliminarDetallesCotizacionPorCodigoYY 7
(YY7 8
ConvertYY8 ?
.YY? @
ToInt32YY@ G
(YYG H
codigoYYH N
)YYN O
)YYO P
;YYP Q
}ZZ 	
}[[ 
}\\ ï
éC:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Dominio\DominioDirecciones.cs
	namespace 	
Dominio
 
{ 
public 

class 
DominioDirecciones #
{ 
DatosDirecciones 
direcciones $
=% &
new' *
DatosDirecciones+ ;
(; <
)< =
;= >
public 
	DataTable 
ShowAddresses &
(& '
)' (
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .
table 
= 
direcciones 
.  
MostrarDirecciones  2
(2 3
)3 4
;4 5
return 
table 
; 
} 	
public 
void 
RegisterAddress #
(# $
string$ *
	direccion+ 4
)4 5
{ 	
direcciones 
. 
InsertarDireccion )
() *
	direccion* 3
)3 4
;4 5
} 	
public 
void 
UpdateAdress  
(  !
string! '
	direccion( 1
,1 2
string3 9
direccionActualizar: M
)M N
{ 	
direcciones 
. 
ActualizaDireccion *
(* +
	direccion+ 4
,4 5
direccionActualizar6 I
)I J
;J K
} 	
} 
} ∑
äC:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Dominio\DominioEntrada.cs
	namespace 	
Dominio
 
{ 
public 

class 
DominioEntrada 
{ 
DatosEntradas 
entrada 
= 
new  #
DatosEntradas$ 1
(1 2
)2 3
;3 4
public 
void 
RegisterEntry !
(! "
DateTime" *
fechaEntrada+ 7
)7 8
{ 	
entrada 
. 
RegistrarEntrada $
($ %
fechaEntrada% 1
)1 2
;2 3
} 	
public 
void  
RegisterDetailsEntry (
(( )
string) /
codigoUsuario0 =
,= >
string? E
suplidorF N
,N O
string 
material 
, 
string $
cantidad% -
,- .
string/ 5
costo6 ;
); <
{ 	
entrada 
. #
RegistrarDetalleEntrada +
(+ ,
Convert, 3
.3 4
ToInt324 ;
(; <
codigoUsuario< I
)I J
,J K
suplidorL T
,T U
material 
, 
Convert "
." #
ToInt32# *
(* +
cantidad+ 3
)3 4
,4 5
float6 ;
.; <
Parse< A
(A B
costoB G
)G H
)H I
;I J
} 	
} 
} ≤_
çC:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Dominio\DominioMateriales.cs
	namespace 	
Dominio
 
{ 
public 

class 
DominioMateriales "
{ 
DatosMateriales		 

materiales		 "
=		# $
new		% (
DatosMateriales		) 8
(		8 9
)		9 :
;		: ;
public 
	DataTable 
ShowMaterials &
(& '
)' (
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
= 

materiales 
. 
MostrarMateriales 0
(0 1
)1 2
;2 3
return 
table 
; 
} 	
public 
	DataTable 
NamesCodesMaterials ,
(, -
)- .
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .
table 
= 

materiales 
. "
NombreCodigoMateriales 5
(5 6
)6 7
;7 8
return 
table 
; 
} 	
public 
	DataTable 
SearchCostMaterial +
(+ ,
string, 2
codigoMaterial3 A
)A B
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .
table   
=   

materiales   
.   
BuscarCostoMaterial   2
(  2 3
Convert  3 :
.  : ;
ToInt32  ; B
(  B C
codigoMaterial  C Q
)  Q R
)  R S
;  S T
return!! 
table!! 
;!! 
}"" 	
public%% 
	DataTable%% 
ReorderPoint%% %
(%%% &
)%%& '
{&& 	
	DataTable'' 
table'' 
='' 
new'' !
	DataTable''" +
(''+ ,
)'', -
;''- .
table(( 
=(( 

materiales(( 
.(( 
PuntoReorden(( +
(((+ ,
)((, -
;((- .
return)) 
table)) 
;)) 
}** 	
public-- 
	DataTable--  
SearchMaterialByCode-- -
(--- .
string--. 4
codigo--5 ;
)--; <
{.. 	
	DataTable// 
table// 
=// 
new// !
	DataTable//" +
(//+ ,
)//, -
;//- .
table00 
=00 

materiales00 
.00 "
BuscarMaterialesCodigo00 5
(005 6
Convert006 =
.00= >
ToInt3200> E
(00E F
codigo00F L
)00L M
)00M N
;00N O
return11 
table11 
;11 
}22 	
public55 
	DataTable55  
SearchMaterialByName55 -
(55- .
string55. 4
nombre555 ;
)55; <
{66 	
	DataTable77 
table77 
=77 
new77 !
	DataTable77" +
(77+ ,
)77, -
;77- .
table88 
=88 

materiales88 
.88 "
BuscarMaterialesNombre88 5
(885 6
nombre886 <
)88< =
;88= >
return99 
table99 
;99 
}:: 	
public== 
	DataTable== "
SearchMaterialByStatus== /
(==/ 0
bool==0 4
estado==5 ;
)==; <
{>> 	
	DataTable?? 
table?? 
=?? 
new?? !
	DataTable??" +
(??+ ,
)??, -
;??- .
table@@ 
=@@ 

materiales@@ 
.@@ "
BuscarMaterialesEstado@@ 5
(@@5 6
estado@@6 <
)@@< =
;@@= >
returnAA 
tableAA 
;AA 
}BB 	
publicEE 
	DataTableEE 
ShowTypeMaterialsEE *
(EE* +
)EE+ ,
{FF 	
	DataTableGG 
tableGG 
=GG 
newGG !
	DataTableGG" +
(GG+ ,
)GG, -
;GG- .
tableHH 
=HH 

materialesHH 
.HH !
MostrarTipoMaterialesHH 4
(HH4 5
)HH5 6
;HH6 7
returnII 
tableII 
;II 
}JJ 	
publicMM 
	DataTableMM !
ShowLeftoverMaterialsMM .
(MM. /
)MM/ 0
{NN 	
	DataTableOO 
tableOO 
=OO 
newOO !
	DataTableOO" +
(OO+ ,
)OO, -
;OO- .
tablePP 
=PP 

materialesPP 
.PP '
MostrarExcedentesMaterialesPP :
(PP: ;
)PP; <
;PP< =
returnQQ 
tableQQ 
;QQ 
}RR 	
publicUU 
voidUU 
RegisterMaterialUU $
(UU$ %
stringUU% +
codigo_tipoMaterialUU, ?
,UU? @
stringUUA G
nombreUUH N
,UUN O
stringUUP V
descripcionUUW b
,UUb c
stringVV 
costoVV 
,VV 
stringVV  

existenciaVV! +
)VV+ ,
{WW 	

materialesXX 
.XX 
RegistrarMaterialXX (
(XX( )
ConvertXX) 0
.XX0 1
ToInt32XX1 8
(XX8 9
codigo_tipoMaterialXX9 L
)XXL M
,XXM N
nombreXXO U
,XXU V
descripcionYY 
,YY 
floatYY "
.YY" #
ParseYY# (
(YY( )
costoYY) .
)YY. /
,YY/ 0
ConvertYY1 8
.YY8 9
ToInt32YY9 @
(YY@ A

existenciaYYA K
)YYK L
)YYL M
;YYM N
}ZZ 	
public]] 
void]] 
UpdateMaterial]] "
(]]" #
string]]# )
codigoMaterial]]* 8
,]]8 9
string]]: @
codigo_tipoMaterial]]A T
,]]T U
string]]V \
nombre]]] c
,]]c d
string]]e k
descripcion]]l w
,]]w x
string^^ 
costo^^ 
,^^ 
string^^  

existencia^^! +
,^^+ ,
bool^^- 1
estado^^2 8
)^^8 9
{__ 	

materiales`` 
.`` 
ActualizarMaterial`` )
(``) *
Convert``* 1
.``1 2
ToInt32``2 9
(``9 :
codigoMaterial``: H
)``H I
,``I J
Convertaa 
.aa 
ToInt32aa 
(aa  
codigo_tipoMaterialaa  3
)aa3 4
,aa4 5
nombreaa6 <
,aa< =
descripcionaa> I
,aaI J
floataaK P
.aaP Q
ParseaaQ V
(aaV W
costoaaW \
)aa\ ]
,aa] ^
Convertbb 
.bb 
ToInt32bb 
(bb  

existenciabb  *
)bb* +
,bb+ ,
estadobb- 3
)bb3 4
;bb4 5
}cc 	
publicff 
voidff  
RegisterTypeMaterialff (
(ff( )
stringff) /
nombreff0 6
)ff6 7
{gg 	

materialeshh 
.hh !
RegistrarTipoMaterialhh ,
(hh, -
nombrehh- 3
)hh3 4
;hh4 5
}ii 	
publicll 
voidll 
UpdateTypeMaterialll &
(ll& '
stringll' -
nombrell. 4
,ll4 5
stringll6 <
nombreNuevoll= H
)llH I
{mm 	

materialesnn 
.nn "
ActualizarTipoMaterialnn -
(nn- .
nombrenn. 4
,nn4 5
nombreNuevonn6 A
)nnA B
;nnB C
}oo 	
publicrr 
voidrr 
DeleteMaterialrr "
(rr" #
stringrr# )
codigorr* 0
)rr0 1
{ss 	

materialestt 
.tt 
EliminarMaterialtt '
(tt' (
Converttt( /
.tt/ 0
ToInt32tt0 7
(tt7 8
codigott8 >
)tt> ?
)tt? @
;tt@ A
}uu 	
publicxx 
voidxx $
RegisterLeftoverMaterialxx ,
(xx, -
stringxx- 3
tipoMaterialxx4 @
,xx@ A
stringxxB H
codigoMaterialxxI W
,xxW X
stringyy 
codigoMedidayy 
,yy  
stringyy! '
largoyy( -
,yy- .
stringyy/ 5
anchoyy6 ;
,yy; <
stringyy= C
altoyyD H
,yyH I
stringyyJ P
cantidadyyQ Y
,yyY Z
stringyy[ a
descripcionyyb m
)yym n
{zz 	

materiales{{ 
.{{ $
RegistrarExcenteMaterial{{ /
({{/ 0
tipoMaterial{{0 <
,{{< =
Convert{{> E
.{{E F
ToInt32{{F M
({{M N
codigoMaterial{{N \
){{\ ]
,{{] ^
Convert|| 
.|| 
ToInt32|| 
(||  
codigoMedida||  ,
)||, -
,||- .
largo||/ 4
,||4 5
ancho||6 ;
,||; <
alto||= A
,||A B
Convert||C J
.||J K
ToInt32||K R
(||R S
cantidad||S [
)||[ \
,||\ ]
descripcion}} 
)}} 
;}} 
}~~ 	
public
ÅÅ 
void
ÅÅ "
UpdateAmountLeftover
ÅÅ (
(
ÅÅ( )
string
ÅÅ) /
codigo
ÅÅ0 6
,
ÅÅ6 7
string
ÅÅ8 >
cantidad
ÅÅ? G
)
ÅÅG H
{
ÇÇ 	

materiales
ÉÉ 
.
ÉÉ )
ActualizarCantidadExcedente
ÉÉ 2
(
ÉÉ2 3
Convert
ÉÉ3 :
.
ÉÉ: ;
ToInt32
ÉÉ; B
(
ÉÉB C
codigo
ÉÉC I
)
ÉÉI J
,
ÉÉJ K
Convert
ÉÉL S
.
ÉÉS T
ToInt32
ÉÉT [
(
ÉÉ[ \
cantidad
ÉÉ\ d
)
ÉÉd e
)
ÉÉe f
;
ÉÉf g
}
ÑÑ 	
public
áá 
void
áá $
UpdateLeftoverMaterial
áá *
(
áá* +
string
áá+ 1
codigoExcedente
áá2 A
,
ááA B
string
ááC I
codigoMedida
ááJ V
,
ááV W
string
ááX ^
largo
áá_ d
,
áád e
string
àà 
ancho
àà 
,
àà 
string
àà  
alto
àà! %
,
àà% &
string
àà' -
cantidad
àà. 6
,
àà6 7
string
àà8 >
descripcion
àà? J
)
ààJ K
{
ââ 	

materiales
ãã 
.
ãã )
ActualizarExcedenteMaterial
ãã 2
(
ãã2 3
Convert
ãã3 :
.
ãã: ;
ToInt32
ãã; B
(
ããB C
codigoExcedente
ããC R
)
ããR S
,
ããS T
Convert
åå 
.
åå 
ToInt32
åå 
(
åå  
codigoMedida
åå  ,
)
åå, -
,
åå- .
largo
åå/ 4
,
åå4 5
ancho
åå6 ;
,
åå; <
alto
åå= A
,
ååA B
Convert
ååC J
.
ååJ K
ToInt32
ååK R
(
ååR S
cantidad
ååS [
)
åå[ \
,
åå\ ]
descripcion
çç 
)
çç 
;
çç 
}
éé 	
public
ëë 
void
ëë $
DeleteLeftoverMaterial
ëë *
(
ëë* +
string
ëë+ 1
codigoExcedente
ëë2 A
)
ëëA B
{
íí 	

materiales
ìì 
.
ìì '
EliminarExcedenteMaterial
ìì 0
(
ìì0 1
Convert
ìì1 8
.
ìì8 9
ToInt32
ìì9 @
(
ìì@ A
codigoExcedente
ììA P
)
ììP Q
)
ììQ R
;
ììR S
}
îî 	
}
ïï 
}ññ ù
äC:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Dominio\DominioMedidas.cs
	namespace 	
Dominio
 
{ 
public 

class 
DominioMedidas 
{ 
DatosMedidas 
medida 
= 
new !
DatosMedidas" .
(. /
)/ 0
;0 1
public 
	DataTable 
ShowMeasurement (
(( )
)) *
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .
table 
= 
medida 
. 
MostrarMedidas )
() *
)* +
;+ ,
return 
table 
; 
} 	
} 
} ´(
éC:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Dominio\DominioProveedores.cs
	namespace 	
Dominio
 
{ 
public 

class 
DominioProveedores #
{ 
DatosProveedores		 
	proveedor		 "
=		# $
new		% (
DatosProveedores		) 9
(		9 :
)		: ;
;		; <
public 
	DataTable 
ShowSuppliers &
(& '
)' (
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
= 
	proveedor 
. 
MostrarProveedores 0
(0 1
)1 2
;2 3
return 
table 
; 
} 	
public 
	DataTable 
NameCodeSupplier )
() *
)* +
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .
table 
= 
	proveedor 
. #
NombreCodigoProveedores 5
(5 6
)6 7
;7 8
return 
table 
; 
} 	
public 
	DataTable  
SearchSupplierByCode -
(- .
string. 4
codigo5 ;
); <
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .
table 
= 
	proveedor 
. !
BuscarProveedorCodigo 3
(3 4
Convert4 ;
.; <
ToInt32< C
(C D
codigoD J
)J K
)K L
;L M
return   
table   
;   
}!! 	
public$$ 
	DataTable$$  
SearchSupplierByName$$ -
($$- .
string$$. 4
nombre$$5 ;
)$$; <
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
='' 
	proveedor'' 
.'' !
BuscarProveedorNombre'' 3
(''3 4
nombre''4 :
)'': ;
;''; <
return(( 
table(( 
;(( 
})) 	
public,, 
	DataTable,, "
SearchSupplierbyStatus,, /
(,,/ 0
bool,,0 4
estado,,5 ;
),,; <
{-- 	
	DataTable.. 
table.. 
=.. 
new.. !
	DataTable.." +
(..+ ,
).., -
;..- .
table// 
=// 
	proveedor// 
.// !
BuscarProveedorEstado// 3
(//3 4
estado//4 :
)//: ;
;//; <
return00 
table00 
;00 
}11 	
public44 
void44 
RegisterSupplier44 $
(44$ %
string44% +
telefono44, 4
,444 5
string446 <
codigoDireccion44= L
,44L M
string44N T
nombreProveedor44U d
)44d e
{55 	
	proveedor66 
.66 
RegistrarProveedor66 (
(66( )
telefono66) 1
,661 2
Convert663 :
.66: ;
ToInt3266; B
(66B C
codigoDireccion66C R
)66R S
,66S T
nombreProveedor66U d
)66d e
;66e f
}77 	
public:: 
void:: 
UpdateSupplier:: "
(::" #
string::# )
telefono::* 2
,::2 3
string::4 :
telefonoViejo::; H
,::H I
string::J P
codigoDireccion::Q `
,::` a
string::b h
nombreProveedor::i x
,::x y
string;; 
codigoProveedor;; "
,;;" #
bool;;$ (
estado;;) /
);;/ 0
{<< 	
	proveedor== 
.== 
ActualizarProveedor== )
(==) *
telefono==* 2
,==2 3
telefonoViejo==4 A
,==A B
Convert==C J
.==J K
ToInt32==K R
(==R S
codigoDireccion==S b
)==b c
,==c d
nombreProveedor>> 
,>>  
Convert>>! (
.>>( )
ToInt32>>) 0
(>>0 1
codigoProveedor>>1 @
)>>@ A
,>>A B
estado>>C I
)>>I J
;>>J K
}?? 	
publicBB 
voidBB 
DeleteSupplierBB "
(BB" #
stringBB# )
codigoSuplidorBB* 8
)BB8 9
{CC 	
	proveedorDD 
.DD 
EliminarProveedorDD '
(DD' (
ConvertDD( /
.DD/ 0
ToInt32DD0 7
(DD7 8
codigoSuplidorDD8 F
)DDF G
)DDG H
;DDH I
}EE 	
}FF 
}GG †9
ãC:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Dominio\DominioReportes.cs
	namespace 	
Dominio
 
{ 
public 

class 
DominioReportes  
{ 
DatosReportes		 
reporte		 
=		 
new		  #
DatosReportes		$ 1
(		1 2
)		2 3
;		3 4
public 
	DataTable 
GeneralEntryReport +
(+ ,
DateTime, 4
fechaInicial5 A
,A B
DateTimeC K

fechaFinalL V
)V W
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
= 
reporte 
. !
ReporteEntradaGeneral 1
(1 2
fechaInicial2 >
,> ?

fechaFinal@ J
)J K
;K L
return 
table 
; 
} 	
public 
	DataTable 
DetailedEntryReport ,
(, -
DateTime- 5
fechaInicial6 B
,B C
DateTimeD L

fechaFinalM W
)W X
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .
table 
= 
reporte 
. #
ReporteEntradaDetallado 3
(3 4
fechaInicial4 @
,@ A

fechaFinalB L
)L M
;M N
return 
table 
; 
} 	
public 
	DataTable 
GeneralSalesReport +
(+ ,
DateTime, 4
fechaInicial5 A
,A B
DateTimeC K

fechaFinalL V
)V W
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .
table   
=   
reporte   
.   !
ReporteSalidasGeneral   1
(  1 2
fechaInicial  2 >
,  > ?

fechaFinal  @ J
)  J K
;  K L
return!! 
table!! 
;!! 
}"" 	
public%% 
	DataTable%% 
DetailedSalesReport%% ,
(%%, -
DateTime%%- 5
fechaInicial%%6 B
,%%B C
DateTime%%D L

fechaFinal%%M W
)%%W X
{&& 	
	DataTable'' 
table'' 
='' 
new'' !
	DataTable''" +
(''+ ,
)'', -
;''- .
table(( 
=(( 
reporte(( 
.(( #
ReporteSalidasDetallado(( 3
(((3 4
fechaInicial((4 @
,((@ A

fechaFinal((B L
)((L M
;((M N
return)) 
table)) 
;)) 
}** 	
public-- 
	DataTable-- 
consultQuotes-- &
(--& '
DateTime--' /
fechaInicial--0 <
,--< =
DateTime--> F

fechaFinal--G Q
)--Q R
{.. 	
	DataTable// 
table// 
=// 
new// !
	DataTable//" +
(//+ ,
)//, -
;//- .
table00 
=00 
reporte00 
.00 !
ConsultarCotizaciones00 1
(001 2
fechaInicial002 >
,00> ?

fechaFinal00@ J
)00J K
;00K L
return11 
table11 
;11 
}22 	
public55 
	DataTable55 
ConsultQuotesByCode55 ,
(55, -
string55- 3
codigo554 :
)55: ;
{66 	
	DataTable77 
table77 
=77 
new77 !
	DataTable77" +
(77+ ,
)77, -
;77- .
table88 
=88 
reporte88 
.88 *
ConsultarCotizacionesPorCodigo88 :
(88: ;
Convert88; B
.88B C
ToInt3288C J
(88J K
codigo88K Q
)88Q R
)88R S
;88S T
return99 
table99 
;99 
}:: 	
public== 
	DataTable== &
ConsultQuotesByDescription== 3
(==3 4
string==4 :
descripcion==; F
)==F G
{>> 	
	DataTable?? 
table?? 
=?? 
new?? !
	DataTable??" +
(??+ ,
)??, -
;??- .
table@@ 
=@@ 
reporte@@ 
.@@ /
#ConsultarCotizacionesPorDescripcion@@ ?
(@@? @
descripcion@@@ K
)@@K L
;@@L M
returnAA 
tableAA 
;AA 
}BB 	
publicEE 
	DataTableEE !
ConsultQuotesByClientEE .
(EE. /
stringEE/ 5
clienteEE6 =
)EE= >
{FF 	
	DataTableGG 
tableGG 
=GG 
newGG !
	DataTableGG" +
(GG+ ,
)GG, -
;GG- .
tableHH 
=HH 
reporteHH 
.HH +
ConsultarCotizacionesPorClienteHH ;
(HH; <
clienteHH< C
)HHC D
;HHD E
returnII 
tableII 
;II 
}JJ 	
publicMM 
	DataTableMM !
ConsultQuotesByStatusMM .
(MM. /
boolMM/ 3
estadoMM4 :
)MM: ;
{NN 	
	DataTableOO 
tableOO 
=OO 
newOO !
	DataTableOO" +
(OO+ ,
)OO, -
;OO- .
tablePP 
=PP 
reportePP 
.PP *
ConsultarCotizacionesPorEstadoPP :
(PP: ;
estadoPP; A
)PPA B
;PPB C
returnQQ 
tableQQ 
;QQ 
}RR 	
publicUU 
	DataTableUU  
ConsultDatailedQuoteUU -
(UU- .
stringUU. 4
codigoUU5 ;
)UU; <
{VV 	
	DataTableWW 
tableWW 
=WW 
newWW !
	DataTableWW" +
(WW+ ,
)WW, -
;WW- .
tableXX 
=XX 
reporteXX 
.XX (
ConsultarCotizacionDetalladaXX 8
(XX8 9
ConvertXX9 @
.XX@ A
ToInt32XXA H
(XXH I
codigoXXI O
)XXO P
)XXP Q
;XXQ R
returnYY 
tableYY 
;YY 
}ZZ 	
public\\ 
	DataTable\\  
ConsultMetadataQuote\\ -
(\\- .
string\\. 4
codigo\\5 ;
)\\; <
{]] 	
	DataTable^^ 
table^^ 
=^^ 
new^^ !
	DataTable^^" +
(^^+ ,
)^^, -
;^^- .
table__ 
=__ 
reporte__ 
.__ (
ConsultarMetaDatosCotizacion__ 8
(__8 9
Convert__9 @
.__@ A
ToInt32__A H
(__H I
codigo__I O
)__O P
)__P Q
;__Q R
return`` 
table`` 
;`` 
}aa 	
}bb 
}cc «
âC:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Dominio\DominioSalida.cs
	namespace 	
Dominio
 
{ 
public		 

class		 
DominioSalida		 
{

 
DatosSalidas 
salidas 
= 
new "
DatosSalidas# /
(/ 0
)0 1
;1 2
public 
	DataTable 
GetCodeSale $
($ %
)% &
{ 	
	DataTable 
table 
= 
new !
	DataTable" +
(+ ,
), -
;- .
table 
= 
salidas 
. 
ObtenerCodigoSalida /
(/ 0
)0 1
;1 2
return 
table 
; 
} 	
public 
void 
SaleOfService !
(! "
DateTime" *
fecha+ 0
)0 1
{ 	
salidas 
. 
RegistrarSalida #
(# $
fecha$ )
)) *
;* +
} 	
public 
void $
add_MultipleSingleInsert ,
(, -
IEnumerable- 8
<8 9
DetallesSalida9 G
>G H
detallesSalidaI W
)W X
{ 	
salidas 
. 
MultiplesSalidas $
($ %
detallesSalida% 3
)3 4
;4 5
} 	
} 
}   ËL
åC:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Dominio\DominioServicios.cs
	namespace 	
Dominio
 
{ 
public 

class 
DominioServicios !
{ 
DatosServicios		 
	servicios		  
=		! "
new		# &
DatosServicios		' 5
(		5 6
)		6 7
;		7 8
public 
void 
RegisterService #
(# $
string$ *
nombreServicio+ 9
,9 :
string; A
descripcionB M
,M N
stringO U
precioV \
,\ ]
bool^ b
estadoc i
)i j
{ 	
	servicios 
. 
RegistrarServicio '
(' (
nombreServicio( 6
,6 7
descripcion8 C
,C D
floatE J
.J K
ParseK P
(P Q
precioQ W
)W X
,X Y
estadoZ `
)` a
;a b
} 	
public 
void #
RegisterMaterialService +
(+ ,
string, 2
codigoMaterial3 A
,A B
stringC I
cantidadJ R
)R S
{ 	
	servicios 
. %
RegistrarMaterialServicio /
(/ 0
Convert0 7
.7 8
ToInt328 ?
(? @
codigoMaterial@ N
)N O
,O P
floatQ V
.V W
ParseW \
(\ ]
cantidad] e
)e f
)f g
;g h
} 	
public 
void &
RegisterNewMaterialService .
(. /
string/ 5
codigoServicio6 D
,D E
stringF L
codigoMaterialM [
,[ \
string] c
cantidadd l
)l m
{ 	
	servicios 
. *
RegistrarNuevoMaterialServicio 4
(4 5
Convert5 <
.< =
ToInt32= D
(D E
codigoServicioE S
)S T
,T U
Convert 
. 
ToInt32 
(  
codigoMaterial  .
). /
,/ 0
Convert1 8
.8 9
ToInt329 @
(@ A
cantidadA I
)I J
)J K
;K L
} 	
public 
void 
UpdateService !
(! "
string" (
codigoServicio) 7
,7 8
string9 ?
nombreServicio@ N
,N O
string   
precio   
,   
string   !
descripcion  " -
,  - .
bool  / 3
estado  4 :
)  : ;
{!! 	
	servicios"" 
."" 
ActualizarServicio"" (
(""( )
Convert"") 0
.""0 1
ToInt32""1 8
(""8 9
codigoServicio""9 G
)""G H
,""H I
nombreServicio""J X
,""X Y
float## 
.## 
Parse## 
(## 
precio## "
)##" #
,### $
descripcion##% 0
,##0 1
estado##2 8
)##8 9
;##9 :
}$$ 	
public'' 
void'' !
UpdateMaterialService'' )
('') *
string''* 0
codigoServicio''1 ?
,''? @
string(( 
codigoMaterial(( !
,((! "
string((# )
materialAnterior((* :
,((: ;
string((< B
cantidad((C K
)((K L
{)) 	
	servicios** 
.** &
ActualizarMaterialServicio** 0
(**0 1
Convert**1 8
.**8 9
ToInt32**9 @
(**@ A
codigoServicio**A O
)**O P
,**P Q
Convert++ 
.++ 
ToInt32++ 
(++  
codigoMaterial++  .
)++. /
,++/ 0
Convert++1 8
.++8 9
ToInt32++9 @
(++@ A
materialAnterior++A Q
)++Q R
,++R S
Convert,, 
.,, 
ToInt32,, 
(,,  
cantidad,,  (
),,( )
),,) *
;,,* +
}-- 	
public00 
void00 !
DeleteMaterialService00 )
(00) *
string00* 0
codigoServicio001 ?
,00? @
string00A G
codigoMaterial00H V
)00V W
{11 	
	servicios22 
.22 $
EliminarMaterialServicio22 .
(22. /
Convert22/ 6
.226 7
ToInt32227 >
(22> ?
codigoServicio22? M
)22M N
,22N O
Convert22P W
.22W X
ToInt3222X _
(22_ `
codigoMaterial22` n
)22n o
)22o p
;22p q
}33 	
public66 
void66 
DeleteService66 !
(66! "
string66" (
codigoServicio66) 7
)667 8
{77 	
	servicios88 
.88 
EliminarServicio88 &
(88& '
Convert88' .
.88. /
ToInt3288/ 6
(886 7
codigoServicio887 E
)88E F
)88F G
;88G H
}99 	
public<< 
void<< 
DeleteServiceStatus<< '
(<<' (
string<<( .
codigoServicio<</ =
)<<= >
{== 	
	servicios>> 
.>> "
EliminarServicioEstado>> ,
(>>, -
Convert>>- 4
.>>4 5
ToInt32>>5 <
(>>< =
codigoServicio>>= K
)>>K L
)>>L M
;>>M N
}?? 	
publicBB 
	DataTableBB 
ShowServicesBB %
(BB% &
)BB& '
{CC 	
	DataTableDD 
tableDD 
=DD 
newDD !
	DataTableDD" +
(DD+ ,
)DD, -
;DD- .
tableEE 
=EE 
	serviciosEE 
.EE 
MostrarServiciosEE .
(EE. /
)EE/ 0
;EE0 1
returnFF 
tableFF 
;FF 
}GG 	
publicJJ 
	DataTableJJ  
ShowServicesNameCodeJJ -
(JJ- .
)JJ. /
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
=MM 
	serviciosMM 
.MM (
MostrarNombreCodigoServiciosMM :
(MM: ;
)MM; <
;MM< =
returnNN 
tableNN 
;NN 
}OO 	
publicRR 
	DataTableRR 
SearchServicePriceRR +
(RR+ ,
stringRR, 2
codigoServicioRR3 A
)RRA B
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
=UU 
	serviciosUU 
.UU  
BuscarPrecioServicioUU 2
(UU2 3
ConvertUU3 :
.UU: ;
ToInt32UU; B
(UUB C
codigoServicioUUC Q
)UUQ R
)UUR S
;UUS T
returnVV 
tableVV 
;VV 
}WW 	
publicZZ 
	DataTableZZ !
ShowMaterialsServicesZZ .
(ZZ. /
stringZZ/ 5
codigoServicioZZ6 D
)ZZD E
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
=]] 
	servicios]] 
.]] &
MostrarMaterialesServicios]] 8
(]]8 9
Convert]]9 @
.]]@ A
ToInt32]]A H
(]]H I
codigoServicio]]I W
)]]W X
)]]X Y
;]]Y Z
return^^ 
table^^ 
;^^ 
}__ 	
publicbb 
	DataTablebb 
SearchServiceCodebb *
(bb* +
stringbb+ 1
codigoServiciobb2 @
)bb@ A
{cc 	
	DataTabledd 
tabledd 
=dd 
newdd !
	DataTabledd" +
(dd+ ,
)dd, -
;dd- .
tableee 
=ee 
	serviciosee 
.ee  
BuscarServicioCodigoee 2
(ee2 3
Convertee3 :
.ee: ;
ToInt32ee; B
(eeB C
codigoServicioeeC Q
)eeQ R
)eeR S
;eeS T
returnff 
tableff 
;ff 
}gg 	
publicjj 
	DataTablejj 
SearchServiceNamejj *
(jj* +
stringjj+ 1
nombreServiciojj2 @
)jj@ A
{kk 	
	DataTablell 
tablell 
=ll 
newll !
	DataTablell" +
(ll+ ,
)ll, -
;ll- .
tablemm 
=mm 
	serviciosmm 
.mm  
BuscarServicioNombremm 2
(mm2 3
nombreServiciomm3 A
)mmA B
;mmB C
returnnn 
tablenn 
;nn 
}oo 	
publicrr 
	DataTablerr 
SearchServiceStatusrr ,
(rr, -
boolrr- 1
estadorr2 8
)rr8 9
{ss 	
	DataTablett 
tablett 
=tt 
newtt !
	DataTablett" +
(tt+ ,
)tt, -
;tt- .
tableuu 
=uu 
	serviciosuu 
.uu  
BuscarServicioEstadouu 2
(uu2 3
estadouu3 9
)uu9 :
;uu: ;
returnvv 
tablevv 
;vv 
}ww 	
}xx 
}yy œG
äC:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Dominio\DominioUsuario.cs
	namespace 	
Dominio
 
{ 
public 

class 
DominioUsuario 
{ 
DatosUsuarios		 
usuario		 
=		 
new		  #
DatosUsuarios		$ 1
(		1 2
)		2 3
;		3 4
private 
int 
codigoUsuario !
;! "
private 
int 
codigo_tipoUsuario &
;& '
private 
string 
tipo_usuario #
;# $
private 
string 
nombreUsuario $
;$ %
private 
string 
password 
;  
private 
string 
nombre 
; 
private 
string 
email 
; 
private 
bool 
estado 
; 
public 
DominioUsuario 
( 
int !
codigoUsuario" /
,/ 0
int1 4
codigo_tipoUsuario5 G
,G H
stringI O
tipo_usuarioP \
,\ ]
string^ d
nombreUsuarioe r
,r s
string 
password 
, 
string #
nombre$ *
,* +
string, 2
email3 8
,8 9
bool: >
estado? E
)E F
{ 	
this 
. 
codigoUsuario 
=  
codigoUsuario! .
;. /
this 
. 
codigo_tipoUsuario #
=$ %
codigo_tipoUsuario& 8
;8 9
this 
. 
tipo_usuario 
= 
tipo_usuario  ,
;, -
this 
. 
nombreUsuario 
=  
nombreUsuario! .
;. /
this 
. 
password 
= 
password $
;$ %
this 
. 
nombre 
= 
nombre  
;  !
this 
. 
email 
= 
email 
; 
this   
.   
estado   
=   
estado    
;    !
}!! 	
public$$ 
DominioUsuario$$ 
($$ 
)$$ 
{$$  !
}$$" #
public'' 
string'' 
EditUserProfile'' %
(''% &
)''& '
{(( 	
try)) 
{** 
usuario++ 
.++ 
ActualizarUsuario++ )
(++) *
codigo_tipoUsuario++* <
,++< =
nombreUsuario++> K
,++K L
nombre++M S
,++S T
password++U ]
,++] ^
email,, 
,,, 
estado,, !
,,,! "
codigoUsuario,,# 0
),,0 1
;,,1 2
usuario.. 
... 
LoginUsuario.. $
(..$ %
nombreUsuario..% 2
,..2 3
password..4 <
)..< =
;..= >
return00 
$str00 B
;00B C
}22 
catch33 
{44 
return55 
$str55 @
;55@ A
}66 
}77 	
public:: 
bool:: 
LoginUsuario::  
(::  !
string::! '
nombreUsuario::( 5
,::5 6
string::7 =
password::> F
)::F G
{;; 	
return<< 
usuario<< 
.<< 
LoginUsuario<< '
(<<' (
nombreUsuario<<( 5
,<<5 6
password<<7 ?
)<<? @
;<<@ A
}== 	
public@@ 
string@@ 
RecoverPassword@@ %
(@@% &
string@@& ,
usuarioSolicitante@@- ?
)@@? @
{AA 	
returnBB 
usuarioBB 
.BB 
RecuperarPasswordBB ,
(BB, -
usuarioSolicitanteBB- ?
)BB? @
;BB@ A
}CC 	
publicFF 
	DataTableFF 
	ShowUsersFF "
(FF" #
)FF# $
{GG 	
	DataTableHH 
tableHH 
=HH 
newHH !
	DataTableHH" +
(HH+ ,
)HH, -
;HH- .
tableII 
=II 
usuarioII 
.II 
	ShowUsersII %
(II% &
)II& '
;II' (
returnJJ 
tableJJ 
;JJ 
}KK 	
publicNN 
	DataTableNN 
ShowTypeUsersNN &
(NN& '
)NN' (
{OO 	
	DataTablePP 
tablePP 
=PP 
newPP !
	DataTablePP" +
(PP+ ,
)PP, -
;PP- .
tableQQ 
=QQ 
usuarioQQ 
.QQ 
TiposUsuariosQQ )
(QQ) *
)QQ* +
;QQ+ ,
returnRR 
tableRR 
;RR 
}SS 	
publicVV 
	DataTableVV 
ShowUsersByCodeVV (
(VV( )
stringVV) /
codigoVV0 6
)VV6 7
{WW 	
	DataTableXX 
tableXX 
=XX 
newXX !
	DataTableXX" +
(XX+ ,
)XX, -
;XX- .
tableYY 
=YY 
usuarioYY 
.YY  
MostrarUsuarioCodigoYY 0
(YY0 1
ConvertYY1 8
.YY8 9
ToInt32YY9 @
(YY@ A
codigoYYA G
)YYG H
)YYH I
;YYI J
returnZZ 
tableZZ 
;ZZ 
}[[ 	
public^^ 
	DataTable^^ 
ShowUsersByName^^ (
(^^( )
string^^) /
nombreUsuario^^0 =
)^^= >
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
=aa 
usuarioaa 
.aa  
MostrarUsuarioNombreaa 0
(aa0 1
nombreUsuarioaa1 >
)aa> ?
;aa? @
returnbb 
tablebb 
;bb 
}cc 	
publicff 
	DataTableff 
ShowUsersByStatusff *
(ff* +
boolff+ /
estadoff0 6
)ff6 7
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
=ii 
usuarioii 
.ii  
MostrarUsuarioEstadoii 0
(ii0 1
estadoii1 7
)ii7 8
;ii8 9
returnjj 
tablejj 
;jj 
}kk 	
publicnn 
voidnn 
RegisterUsernn  
(nn  !
stringnn! '
codigo_TipoUsuarionn( :
,nn: ;
stringnn< B
nombre_usuarionnC Q
,nnQ R
stringnnS Y
nombrennZ `
,nn` a
stringoo 
passwordoo 
,oo 
stringoo #
emailoo$ )
)oo) *
{pp 	
usuarioqq 
.qq 
RegistrarUsuarioqq $
(qq$ %
Convertqq% ,
.qq, -
ToInt32qq- 4
(qq4 5
codigo_TipoUsuarioqq5 G
)qqG H
,qqH I
nombre_usuarioqqJ X
,qqX Y
nombreqqZ `
,qq` a
passwordqqb j
,qqj k
emailqql q
)qqq r
;qqr s
}rr 	
publicuu 
voiduu 

UpdateUseruu 
(uu 
stringuu %
codigo_tipoUsuariouu& 8
,uu8 9
stringuu: @
nombre_usuariouuA O
,uuO P
stringuuQ W
nombreuuX ^
,uu^ _
stringvv 
passwordvv 
,vv 
stringvv #
emailvv$ )
,vv) *
boolvv+ /
estadovv0 6
,vv6 7
stringvv8 >
codigoUsuariovv? L
)vvL M
{ww 	
usuarioxx 
.xx 
ActualizarUsuarioxx %
(xx% &
Convertxx& -
.xx- .
ToInt32xx. 5
(xx5 6
codigo_tipoUsuarioxx6 H
)xxH I
,xxI J
nombre_usuarioxxK Y
,xxY Z
nombrexx[ a
,xxa b
passwordyy 
,yy 
emailyy 
,yy  
estadoyy! '
,yy' (
Convertyy) 0
.yy0 1
ToInt32yy1 8
(yy8 9
codigoUsuarioyy9 F
)yyF G
)yyG H
;yyH I
}zz 	
public}} 
void}} 

DeleteUser}} 
(}} 
string}} %
codigoUsuario}}& 3
)}}3 4
{~~ 	
usuario 
. 
EliminarUsuario #
(# $
Convert$ +
.+ ,
ToInt32, 3
(3 4
codigoUsuario4 A
)A B
)B C
;C D
}
ÄÄ 	
}
ÅÅ 
}ÇÇ ø
ìC:\Users\Cesar Baez\Desktop\Universidad UAPA\SistemaInventario_JucebaComercial\SistemaInventario_JucebaComercial\Dominio\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 

AssemblyTitle 
( 
$str "
)" #
]# $
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
$str $
)$ %
]% &
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