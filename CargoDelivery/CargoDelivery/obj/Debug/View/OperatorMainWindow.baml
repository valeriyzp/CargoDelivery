   M S B A M L   `   `   `  ����H  DCargoDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CargoDelivery.ViewCargoDelivery.View  5   	   +    %CargoDelivery.View.OperatorMainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:CargoDelivery.View     5   	     � Title$!  Main window | CargoDelivery��5   	   $	��550��6-   $	��350��6:    � 
ResizeMode$ NoResize=�6F    � Icon$" /Resources/CargoDelivery.ico��6\    � 	Resources 5	         scbMenu  GreyTextOverTextBlock �� Property �� Value  GreyTextBox �� 
TargetType��%�  &	        &	      &	 �     ��5
   
   #D3D3D3��63   �� 5   
   .�5      ��  � ��$ 14(�61   �� 5       � �� �	#9900000063   �� 5       � ��$ 0 0 0 5q�6/   �� 5       � ��$
 Left=�6<   5      �� 5   
   " ��6$   .�5      ��  � ��$ 14(�61   �� 5       � ��$ 24��6/   �� 5       � ��$ 2q�68   5      5       J� InputBindings 5      �� 5   
    �� 	Modifiers$
 Ctrlf�6   
	 �� Key$	 F��6&   
 �� Command
 6.   �� *FindOrderCommand+�� 5   
   $
 Ctrlf�6   $	 N��6&   
 6.   �� *NewOrderCommand+�� 5   
   $
 Ctrlf�6   $	 O��6&   
 6.   �� *AddOrderToTruckCommand+�� 5   
   $
 Ctrlf�6   $	 T��6&   
 6.   �� *TruckArrivalCommand+.��5      �� #��[  6   ._�5   
   �� $��10q�6   
������� �� CornerRadius$ 10��60   ._�5      �� .+�5       �� $��Orders managment��6   $��20q�65   .��5!      �� $��10q�6!   .+�5"      �� $��
Find order��6#   $��10q�67   .��5#      �� $��10q�6)   .+�5$   "   �� #��[ 6,   $��Number��6[   �� 5%   "   #��[ 6*   ��6O   �� *Number+ �� UpdateSourceTrigger$ PropertyChanged=��� 5&   "   $��	0 20 0 10q�6)   $��14(�6<   $	��120��6J   $��32��6V   $
��Find��6b   $��Center=�6q   ��6�   �� *FindOrderCommand+5'      5(      �� 5)      $��	0 20 0 10q�6!   $��14(�64   $	��120��6B   $��32��6N   $��	New order��6Z   $��Center=�6n   ��6�   �� *NewOrderCommand+5*      5+      �� 5,      $��Trucks managment��6   $��
20 0 20 20q�65   .��5-      �� $��10q�6!   .+�5.      �� $��	0 10 0 10q�6!   $��14(�64   $	��120��6B   $��32��6N   $��Add order to truck��6Z   $��Center=�6w   ��6�   �� *AddOrderToTruckCommand+�� 5/      $��	0 20 0 10q�6!   $��14(�64   $	��120��6B   $��32��6N   $��Truck arrival��6Z   $��Center=�6r   ��6�   �� *TruckArrivalCommand+50      51      52      53      54      55      