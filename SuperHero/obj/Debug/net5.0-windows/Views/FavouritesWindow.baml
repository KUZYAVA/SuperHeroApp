   M S B A M L   `   `   `  ????D  @SuperHero, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SuperHero.ViewsSuperHero.Views  5   	   &     SuperHero.Views.FavouritesWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   )localclr-namespace:SuperHero.Views  5   	   -   5        $??
Favourites??5
   	     ? WindowStartupLocation$  CenterOwner=?5   	    ? Title$# Избранные герои??5   	   $	??450??6!   $	??800??6.   .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5       ? ColumnDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      .+?5   
   ?? ???#434343 ?? Padding$ 15q?6&   $??2??63   ._?5      ?  5      ?? 5      $
??Auto ?6'   ?? 5      ?? 5      ?? 5      .+?5      ?? $	??700??5       $??1??5!      $??2??5"      
???????)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Поиск??5$       %  !MaterialDesignFloatingHintTextBox#??[  5%      ?? 5&      $??0??6   $
??Left=?5'      $??На главную??5(      $	??150??5)      $
??10 0q?5*      $??14(?5+      $	??250??5-       ? Cursor$
 Hand??6h   ??5,      ?? *BackToMainWindow+??5-   (   ?? *ActualWidth+ ?? ElementName$ listBox?? ?? Mode$ OneWay=?6h   5.      5/      ?? 52   
   ???#F6F6F6$??1??6,   $??0??69   $??Center=?6I   $??15q?6f   $
??True??6s   $
??Auto=?6?   .??53      ?? -   5        	 ??Name$	 listBox??53      $
??15 5q?6'   ??65   ?? *FavouriteHeroes+
 ?? SelectedItem
 6]   ?? *SelectedHero+??54      ?? 55      .R?56      ?? $??18(?6$   ??62   ??  ?? Path$
 Name?57      59      5:      ?? 5=   
   $??1??6   $??1??6!   $ 	15 15 0 0q?6.   ._?5>      ?  5?      ?? 5@      $
??Auto ?6'   ?? 5A       5C      ?? 5D      ?? 5E      ?? 5F      .+?5H      ?? -   5         ??Name$ image??5H      $??0 0 15 0q?6Q   $??0??6c   $??0??6s   $??2??6?   ??6'   ?? *SelectedHero.Images.Lg+6?   ?? 5I      $??0??6   $??1??6*   $??3??6:   .+?5J      ?? $??32(?6    $
??Wrap=?6Q   ??6.   ?? *SelectedHero.Name+6Q   ?? 5K      $??20(?6    $
??Wrap=?6h   ??6.   ?? *SelectedHero.Id+ ?? StringFormat$ 
• id:{0}??6h   ?? 5L      $??20(?6    $
??Wrap=?6m   ??6.   ?? *SelectedHero.PowerStats+$ • {0}??6m   ?? 5M      $??20(?6    $
??Wrap=?6m   ??6.   ?? *SelectedHero.Appearance+$ • {0}??6m   ?? 5N      $??20(?6    $
??Wrap=?6l   ??6.   ?? *SelectedHero.Biography+$ • {0}??6l   ?? 5O      $??20(?6    $
??Wrap=?6g   ??6.   ?? *SelectedHero.Work+$ • {0}??6g   ?? 5P      $??20(?6    $
??Wrap=?6n   ??6.   ?? *SelectedHero.Connections+$ • {0}??6n   5Q      ?? 5R      $.??(Удалить из избранного??6B   $??2??6b   $	??Top=?6o   $??15q?6?   $	??250??6?   $
 Hand??6?   ??6   ?? *DeleteFromFavourites+??6?   ?? *ActualWidth+$ image??$ OneWay=?6?   5S      5T      5U      5V      