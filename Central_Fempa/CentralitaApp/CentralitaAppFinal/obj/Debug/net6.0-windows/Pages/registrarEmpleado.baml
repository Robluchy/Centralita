   M S B A M L   `   `   `  ????M  ICentralitaAppFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CentralitaAppFinalCentralitaAppFinal  5      *    $CentralitaAppFinal.registrarEmpleado   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:CentralitaAppFinal     5        N? 
Background  ?#094F73 N? Title$ registrarEmpleado??5
      .??5      ?  ? RowDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6    ? ColumnDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   .+?5   
   ?? $??Alta usuarios??6   $??0??6(   $??0??65   $??3??6E   $??Center=?6Y   $??Center=?6v   $??30(?6?   
???????6?   ?? 5   
   $??NOMBRE Y APELLIDO * :??6   $??1??60   $??Center=?6>   $
??Bold"?6[   $$??Tw Cen MT Condensed Extra Bold)?6m   $??18(?6?   $??Center=?6?   ?? 5   
   -   5         ??Name$ 	txtNombre??5      $??Center=?6%   $??18(?6G   $??1??6U   $??1??6b   $??10q?6r   
???????$??2??6?   $??50??6?   ?? 5!   
   $??CONTRASEÑA :??6   $??2??6(   $??Center=?65   $
??Bold"?6S   $$??Tw Cen MT Condensed Extra Bold)?6e   $??18(?6?   $??Center=?6?   ?? 5"   
   -   5        $ password??5"      $??Center=?6$   $??18(?6F   $??2??6U   $??1??6b   
???????$??10q?6?   $??2??6?   $??50??6?   ?? 5$   
   $??
TELEFONO :??6   $??3??6&   $??Center=?63   $
??Bold"?6S   $$??Tw Cen MT Condensed Extra Bold)?6e   $??18(?6?   $??Center=?6?   ?? 5%   
   -   5        $ 	telefonoE??5%      $??Center=?6%   $??18(?6G   $??3??6V   $??1??6c   
???????$??10q?6?   $??2??6?   $??50??6?   6?   ?? 5'   
   $??
 EMAIL * :??6   $??4??6'   $??Center=?64   $
??Bold"?6S   $$??Tw Cen MT Condensed Extra Bold)?6e   $??18(?6?   $??Center=?6?   ?? 5(   
   -   5        $ 	txtCorreo??5(      $??Center=?6%   $??18(?6G   $??4??6V   $??1??6c   
???????$??10q?6?   $??2??6?   $??50??6?   ?? 5*   
    ?? Orientation$ 
Horizontal=?6   $??1??6.   $??5??6>   $??Center=?6K   $??Center=?6h   .+?5+      ?? -   5         ??Name$ btnRegistrar??5+      $??	REGISTRAR??6+   
???????$??50??6R   $	??150??6^   $??18(?6k   $
??Bold"?6y   $$??Tw Cen MT Condensed Extra Bold)?6?   $??10q?6?   6?   ?? 5,      -   5        $ btnCancelar??5,      $??VOLVER??6*   
???????$??18(?6O   $	??150??6]   $
??Bold"?6i   $$??Tw Cen MT Condensed Extra Bold)?6{   $??10q?6?   6?   5-      ? 5/   
   -   5         ?Name$ registroEmpleadoPopup??5/      $??
MousePoint=?6/   $??False??6F   .??50      ?? 
??? ? ? ?? Padding$ 10q?6(   ._?51      ?? -   5        	 ??Name$	 registroEmpleadoTextBlock??51      
 ?? TextAlignment$
 Center=?6?   52      54      56      57      