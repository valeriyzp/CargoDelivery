   M S B A M L   `   `   `  ����H  DCargoDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CargoDelivery.ViewCargoDelivery.View  5   	   0    *CargoDelivery.View.OperatorOrderInfoWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:CargoDelivery.View     5   	   $	��750��5   \   $	��750��6i     � Icon$"  /Resources/CargoDelivery.ico��6u    � Title 6	   �� *order.Number+ �� StringFormat$+ %Order {0} information | CargoDelivery�� � 	Resources 5	         scbMenu  GreyTextOverTextBlock �� Property �� Value  GreyTextBox �� 
TargetType  GreyComboBox  
ErrorLabel��%�  &	        &	      &	 �     &	 h    &	 �    ��5
   
   #D3D3D3��63   �� 5   
   .�5      ��  � ��$ 14(�61   �� 5       � �� �	#9900000063   �� 5       � ��$ 0 10 0 5q�6/   �� 5       � ��$
 Left=�6<   5      �� 5   
   " ��6$   .�5      ��  � ��$ 14(�61   �� 5       � ��$ 24��6/   �� 5       � ��$ 2q�68   5      �� 5   
   .�5      ��  � ��$ 14(�61   �� 5       � ��$ 24��6/   �� 5       � ��$ 2q�68   5      �� 5   
   .�5      ��  � ��$ 12(�61   �� 5       � ��$ 26��6/   �� 5       � ��
 �  ��63   �� 5       � ��$ 
5, 5, 0, 0q�60   �� 5        � ��$ 
0, 0, 0, 5q�6/   5!      5"       J� InputBindings 5#      �� 5$   
    �� 	Modifiers$
 Ctrlf�6   
	 �� Key$	 S��6&   
 �� Command
 6.   �� *SaveChangesCommand+�� 5%   
   $
 Ctrlf�6   $	 P��6&   
 6.   �� *PaymentCommand+�� 5&   
   $
 Ctrlf�6   $	 R��6&   
 6.   �� *ReceiveCommand+.��5(      �� #��[  6   ._�5)   
   �� .��5*      �� $��10q�6    �� Padding$ 20q�6!   
������� �� CornerRadius$ 10��6A   ._�5+      �  � ColumnDefinitions 5,      �� 5-      $��* �6,   �� 5.      $
��auto �6+   .+�50      � 
������� 51      �� 52      �� 53       � RowDefinitions 55      �� 56      $
��Auto �6,   �� 57      $
��Auto �6,   �� 58      $
��auto �6,   .+�5:      �� $��Sender��6#   $��20q�63   .��5;      �� $��10q�6)   .+�5<   "   �� #��[ 6,   $��
First name��6[   �� 5=   "   -   5        $��tbSenderFirstName��5=   *   #��[ 6D   ��6i   �� *order.SenderFirstName+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . �� 5>   "   #��[ 6(   ��6L   ��  �� ElementName$ tbSenderFirstName�� �� Path$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 5?   "   #��[ 6,   $��	Last name��6[   �� 5@   "   -   5        $��tbSenderLastName��5@   *   #��[ 6C   ��6h   �� *order.SenderLastName+$ PropertyChanged=� . �� 5A   "   #��[ 6(   ��6L   �� $ tbSenderLastName��$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 5B   "   #��[ 6,   $��Phone number��6[   �� 5C   "   -   5        $��tbSenderPhoneNumber��5C   *   #��[ 6F   ��6k   �� *order.SenderPhoneNumber+$ PropertyChanged=� . �� 5D   "   #��[ 6(   ��6L   �� $ tbSenderPhoneNumber��$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 5E   "   #��[ 6,   $
��City��6[   �� 5F   "   -   5        $��tbSenderCity��5F   *   #��[ 6?   ��6d   �� *order.SenderCity+$ PropertyChanged=� . �� 5G   "   #��[ 6(   $��0q�6L   ��6W   �� $ tbSenderCity��$2 ,(Validation.Errors).CurrentItem.ErrorContent�5H      5I      �� 5J      $��1��6#   $��Receiver��64   $��20q�6F   .��5K      �� $��10q�6)   .+�5L   "   �� #��[ 6,   $��
First name��6[   �� 5M   "   -   5        $��tbReceiverFirstName��5M   *   #��[ 6F   ��6k   �� *order.ReceiverFirstName+$ PropertyChanged=� . �� 5N   "   #��[ 6(   ��6L   �� $ tbReceiverFirstName��$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 5O   "   #��[ 6,   $��	Last name��6[   �� 5P   "   -   5        $��tbReceiverLastName��5P   *   #��[ 6E   ��6j   �� *order.ReceiverLastName+$ PropertyChanged=� . �� 5Q   "   #��[ 6(   ��6L   �� $ tbReceiverLastName��$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 5R   "   #��[ 6,   $��Phone number��6[   �� 5S   "   -   5        $��tbReceiverPhoneNumber��5S   *   #��[ 6H   ��6m   �� *order.ReceiverPhoneNumber+$ PropertyChanged=� . �� 5T   "   #��[ 6(   ��6L   �� $ tbReceiverPhoneNumber��$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 5U   "   #��[ 6,   $
��City��6[   �� 5V   "   -   5        $��tbReceiverCity��5V   *   #��[ 6A   ��6f   �� *order.ReceiverCity+$ PropertyChanged=� . �� 5W   "   #��[ 6(   $��0q�6L   ��6W   �� $ tbReceiverCity��$2 ,(Validation.Errors).CurrentItem.ErrorContent�5X      5Y      �� 5Z      $��1��6#   $��2��60   $��Cargo information��6E   $��
20 0 20 20q�6`   .��5[      � 
������� 5\   "   �� 5]   &   �� 5^   &   .+�5`   "   �� $��10 10 35 10q�6-   .+�5a   &   �� #��[ 60   $
��Type��6_   �� 5b   &   -	   5        $��tbType��5b   �   #��[ 6w   ��6/   �� *order.Types+ �� SelectedItem 6S   �� *
order.Type+6�   �� 5c   &   #��[ 6,   ��6P   �� $ tbType��$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 5d   &   #��[ 60   $��
Weight, kg��6_   �� 5e   &   -
   5        $��tbWeight��5e   .   #��[ 6?   ��6d   �� *order.Weight+$ PropertyChanged=� . �� 5f   &   #��[ 6,   ��6P   �� $ tbWeight��$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 5g   &   #��[ 60   $��Declared price, UAH��6_   �� 5h   &   -   5        $��tbDeclaredPrice��5h   .   #��[ 6F   ��6k   �� *order.DeclaredPrice+$ PropertyChanged=� . �� 5i   &   #��[ 6,   $��0q�6P   ��6[   �� $ tbDeclaredPrice��$2 ,(Validation.Errors).CurrentItem.ErrorContent�5j   #   �� 5k   "   $��1��6-   $��35 10 10 10q�6=   .+�5l   &   �� #��[ 60   $��
Length, sm��6_   �� 5m   &   -   5        $��tbSizeX��5m   .   #��[ 6>   ��6c   �� *order.Size_X+$ PropertyChanged=� . �� 5n   &   #��[ 6,   ��6P   �� $ tbSizeX��$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 5o   &   #��[ 60   $��
Height, sm��6_   �� 5p   &   -   5        $��tbSizeY��5p   .   #��[ 6>   ��6c   �� *order.Size_Y+$ PropertyChanged=� . �� 5q   &   #��[ 6,   ��6P   �� $ tbSizeY��$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 5r   &   #��[ 60   $��	Width, sm��6_   �� 5s   &   -   5        $��tbSizeZ��5s   .   #��[ 6>   ��6c   �� *order.Size_Z+$ PropertyChanged=� . �� 5t   &   #��[ 6,   $��0q�6P   ��6[   �� $ tbSizeZ��$2 ,(Validation.Errors).CurrentItem.ErrorContent�5u   #   5v      5w      �� 5x      $��2��6#   $��2��60   $��Delivery information��6E   $��
20 0 20 20q�6c   .��5y      � 
������� 5z   "   �� 5{   &   �� 5|   &   .+�5~   "   �� $��
10 0 35 10q�6-   .+�5   &   �� #��[ 60   $��
Price, UAH��6_   �� 5�   &    �� 
IsReadOnly . #��[ 6]   ��6@   �� *order.Price+6]   �� 5�   &   #��[ 60   $��Status��6_   �� 5�   &    . #��[ 6@   ��6e   �� *order.Status+$ PropertyChanged=� . �� 5�   &   #��[ 60   $��Payment��6_   �� 5�   &    . #��[ 6@   ��6e   �� *order.IsPaid+$ PropertyChanged=� . 5�   #   �� 5�   "   $��1��6-   $��
35 0 10 10q�6=   .+�5�   &   �� #��[ 60   $��Date clearance��6_   �� 5�   &    . #��[ 6@   ��6e   �� *order.DateClearance+$ PropertyChanged=� . �� 5�   &   #��[ 60   $��Date receiving��6_   �� 5�   &    . #��[ 6@   ��6e   �� *order.DateReceiving+$ PropertyChanged=� . 5�   #   5�      5�      5�      �� 5�      $��1��6!   $��10q�61   .+�5�      �� $��	0 30 0 10q�6!   $��14(�64   $	��120��6B   $��32��6N   $��Save changes��6Z   ��6q   �� *SaveChangesCommand+�� 5�      $��	0 30 0 10q�6!   $��14(�64   $	��120��6B   $��32��6N   $��Payment��6Z   ��6l   �� *PaymentCommand+�� 5�      $��	0 30 0 10q�6!   $��14(�64   $	��120��6B   $��32��6N   $��Receive��6Z   ��6l   �� *ReceiveCommand+5�      5�      5�      5�      5�      5�      