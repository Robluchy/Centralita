   M S B A M L   `   `   `  ????M  ICentralitaAppFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CentralitaAppFinalCentralitaAppFinal  5      )    #CentralitaAppFinal.MostrarRegistros   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:CentralitaAppFinal     5        N? Title$  MostrarRegistros??5	      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $??* ?6    ? RowDefinitions 5   
   ?? 5      ?? 5      $	??100 ?6   .+?5   
   ??  ?? Orientation$ 
Horizontal=?6   $??1??6.   $??1??6;   $??Center=?6K   $??10q?6h   .+?5      ?? $??	Registros??6   $??18(?6(   $??Center=?66   $??Center=?6S   $??0,0,50,0q?6n   ?? 5      -   5         ??Name$ btnImprimir??5      $??Imprimir??6*   $$??Tw Cen MT Condensed Extra Bold)?6=   $??18(?6i   ???#77dd77$??90??6?   $??30??6?   6?   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$
 grid??5      $??30q?6!      AutoGenerateColumns$ False??6X   $??0??6t   $??0??6?      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=?6%   	   Header$	 Indentidador??69   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6P   ??  ?? Path$ id?  5      $	 email??6%   
 64   ?? $ email?  5      $	 empresa??6%   
 66   ?? $ empresa?  5      $	 fecha??6%   
 64   ?? $ 
fecha_hora?  5       $	 motivo??6%   
 65   ?? $ motivo?  5!      $	 nombre??6%   
 65   ?? $ nombre_persona?  5"      $	 observaciones??6%   
 6<   ?? $ observaciones?  5#      $	 telefono??6%   
 67   ?? $ telefono_persona?5%      5(      5)      