   M S B A M L   `   `   `  ����H  DCargoDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CargoDelivery.ViewCargoDelivery.View  5      +    %CargoDelivery.View.ConsumerOrdersPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:CargoDelivery.View     5        N� Title$*  $Consumer orders page | CargoDelivery��5	       � 	Resources 5
         tbItems �� Property �� Value  scbItem 
 tbItem �� 
TargetType��%�   &	        &	 >     &	 ]     �� 5   
   .�5      ��  � ��$ 18(�61   5      ��5   
   #F1F0F0��63   �� 5   
   " ��6   .�5      ��  � ��$ 18(�61   5      5      .��5      � .+�5   
   �� -   5         ��Name$ ConsumerOrders��5   $   $��0 5 0 0q�6   $��0q�6<    %� 
ScrollUnit$ Pixel=�6w   $��Stretch=�6�   $��Disabled=�6�   ��6P   �� *ConsumerOrders+��5      �� 5      .R�5      �� #��[ 6    �� CornerRadius$ 10��6C   $��	10 5 10 5q�6U   ._�5      � $��60��6   }�.  � ColumnDefinitions 5      �� 5   "   $	��150 �63   �� 5   "   $
��165* �63   �� 5   "   $
��165* �63   �� 5   "   $��50 �63   .+�5      �� $��Center=�6)   $��10q�6D   .+�5    "   �� #��[ 6,   $	��Id:��6M   �� 5!   "   #��[ 6,   ��6L   �� *Number+5"      �� 5#      $��1��6)   $��Center=�69   $��10q�6U   .+�5$   "   �� #��[ 6,   ��6L   �� *SenderFirstPlusLastName+	 �� StringFormat$	 	From: {0}���� 5%   "   #��[ 6,   ��6L   �� *
SenderCity+5&      �� 5'      $��2��6)   $��Center=�69   $��10q�6U   .+�5(   "   �� #��[ 6,   ��6L   �� *ReceiverFirstPlusLastName+$	 To: {0}���� 5)   "   #��[ 6,   ��6L   �� *ReceiverCity+5*      �� 5+      $��3��6%   $��Center=�65   $��Center=�6P   
������ $��0q�6�   $��10q�6�   ��6�   �� 
 �� ElementName$
 ConsumerOrders�� �� Path$* $DataContext.ShowSelectedOrderCommand���6   �� .��5,   "   �� $#��/Resources/OrderInfoImage.png��6(   $��26��6O   $��32��6Z   $
��Fill=�6f   5-      5.      5/      50      52      53      54      