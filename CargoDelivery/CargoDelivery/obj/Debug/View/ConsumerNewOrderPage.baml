   M S B A M L   `   `   `  ����H  DCargoDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CargoDelivery.ViewCargoDelivery.View  5      -    'CargoDelivery.View.ConsumerNewOrderPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:CargoDelivery.View     5        N� Title$-  'Consumer new order page | CargoDelivery��5	       � 	Resources 5
         GreyTextOverTextBlock �� Property �� Value  GreyTextBox �� 
TargetType  GreyComboBox  
ErrorLabel��%�  &	        &	 �     &	 H    &	 �    �� 5   
   .�5      ��  � ��$ 14(�61   �� 5       � �� �	#9900000063   �� 5       � ��$ 0 0 0 5q�6/   �� 5       � ��$
 Left=�6<   5      �� 5   
   " ��6$   .�5      ��  � ��$ 14(�61   �� 5       � ��$ 24��6/   �� 5       � ��$ 2q�68   5      �� 5   
   .�5      ��  � ��$ 14(�61   �� 5       � ��$ 24��6/   �� 5       � ��$ 2q�68   5      �� 5   
   .�5      ��  � ��$ 12(�61   �� 5       � ��$ 26��6/   �� 5       � ��
 �  ��63   �� 5       � ��$ 
5, 5, 0, 0q�60   �� 5        � ��$ 
0, 0, 0, 5q�6/   5!      5"      .��5#      �� .��5$   
   � 
������� � ColumnDefinitions 5%      �� 5&      �� 5'       � RowDefinitions 5)      �� 5*      $
��Auto �6    �� 5+      $
��Auto �6    �� 5,      $��* �6    .+�5.      �� $��Sender��6   $��20q�6'   .��5/      �� $��10q�6   .+�50      �� #��[  6    $��
First name��6O   �� 51      -   5        $��tbSenderFirstName��51      #��[ 68   ��6]   �� *NewOrder.SenderFirstName+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . �� 52      #��[ 6   ��6@   �� 	 �� ElementName$	 tbSenderFirstName��
 �� Path$2
 ,(Validation.Errors).CurrentItem.ErrorContent��� 53      #��[  6    $��	Last name��6O   �� 54      -   5        $��tbSenderLastName��54      #��[ 67   ��6\   �� *NewOrder.SenderLastName+$ PropertyChanged=� . �� 55      #��[ 6   ��6@   �� $	 tbSenderLastName��$2
 ,(Validation.Errors).CurrentItem.ErrorContent��� 56      #��[  6    $��Phone number��6O   �� 57      -   5        $��tbSenderPhoneNumber��57      #��[ 6:   ��6_   �� *NewOrder.SenderPhoneNumber+$ PropertyChanged=� . �� 58      #��[ 6   ��6@   �� $	 tbSenderPhoneNumber��$2
 ,(Validation.Errors).CurrentItem.ErrorContent��� 59      #��[  6    $
��City��6O   �� 5:      -   5        $��tbSenderCity��5:      #��[ 63   ��6X   �� *NewOrder.SenderCity+$ PropertyChanged=� . �� 5;      #��[ 6   $��0q�6@   ��6K   �� $	 tbSenderCity��$2
 ,(Validation.Errors).CurrentItem.ErrorContent�5<      5=      �� 5>      $��1��6   $��Receiver��6(   $��20q�6:   .��5?      �� $��10q�6   .+�5@      �� #��[  6    $��
First name��6O   �� 5A      -   5        $��tbReceiverFirstName��5A      #��[ 6:   ��6_   �� *NewOrder.ReceiverFirstName+$ PropertyChanged=� . �� 5B      #��[ 6   ��6@   �� $	 tbReceiverFirstName��$2
 ,(Validation.Errors).CurrentItem.ErrorContent��� 5C      #��[  6    $��	Last name��6O   �� 5D      -   5        $��tbReceiverLastName��5D      #��[ 69   ��6^   �� *NewOrder.ReceiverLastName+$ PropertyChanged=� . �� 5E      #��[ 6   ��6@   �� $	 tbReceiverLastName��$2
 ,(Validation.Errors).CurrentItem.ErrorContent��� 5F      #��[  6    $��Phone number��6O   �� 5G      -   5        $��tbReceiverPhoneNumber��5G      #��[ 6<   ��6a   �� *NewOrder.ReceiverPhoneNumber+$ PropertyChanged=� . �� 5H      #��[ 6   ��6@   �� $	 tbReceiverPhoneNumber��$2
 ,(Validation.Errors).CurrentItem.ErrorContent��� 5I      #��[  6    $
��City��6O   �� 5J      -   5        $��tbReceiverCity��5J      #��[ 65   ��6Z   �� *NewOrder.ReceiverCity+$ PropertyChanged=� . �� 5K      #��[ 6   $��0q�6@   ��6K   �� $	 tbReceiverCity��$2
 ,(Validation.Errors).CurrentItem.ErrorContent�5L      5M      �� 5N      $��1��6   $��2��6$   $��Cargo information��69   $��
20 0 20 20q�6T   .��5O      � 
������� 5P      �� 5Q      �� 5R      .+�5T      �� $��10 10 35 10q�6!   .+�5U      �� #��[  6$   $
��Type��6S   �� 5V      -	   5        $��tbType��5V   �   #��[ 6q   ��6#   �� *NewOrder.Types+ �� SelectedItem 6J   �� *NewOrder.Type+6�   �� 5W      #��[ 6    ��6D   �� $	 tbType��$2
 ,(Validation.Errors).CurrentItem.ErrorContent��� 5X      #��[  6$   $��
Weight, kg��6S   �� 5Y      -
   5        $��tbWeight��5Y   "   #��[ 63   ��6X   �� *NewOrder.Weight+$ PropertyChanged=� . �� 5Z      #��[ 6    ��6D   �� $	 tbWeight��$2
 ,(Validation.Errors).CurrentItem.ErrorContent��� 5[      #��[  6$   $��Declared price, UAH��6S   �� 5\      -   5        $��tbDeclaredPrice��5\   "   #��[ 6:   ��6_   �� *NewOrder.DeclaredPrice+$ PropertyChanged=� . �� 5]      #��[ 6    $��0q�6D   ��6O   �� $	 tbDeclaredPrice��$2
 ,(Validation.Errors).CurrentItem.ErrorContent�5^      �� 5_      $��1��6!   $��35 10 10 10q�61   .+�5`      �� #��[  6$   $��
Length, sm��6S   �� 5a      -   5        $��tbSizeX��5a   "   #��[ 62   ��6W   �� *NewOrder.Size_X+$ PropertyChanged=� . �� 5b      #��[ 6    ��6D   �� $	 tbSizeX��$2
 ,(Validation.Errors).CurrentItem.ErrorContent��� 5c      #��[  6$   $��
Height, sm��6S   �� 5d      -   5        $��tbSizeY��5d   "   #��[ 62   ��6W   �� *NewOrder.Size_Y+$ PropertyChanged=� . �� 5e      #��[ 6    ��6D   �� $	 tbSizeY��$2
 ,(Validation.Errors).CurrentItem.ErrorContent��� 5f      #��[  6$   $��	Width, sm��6S   �� 5g      -   5        $��tbSizeZ��5g   "   #��[ 62   ��6W   �� *NewOrder.Size_Z+$ PropertyChanged=� . �� 5h      #��[ 6    $��0q�6D   ��6O   �� $	 tbSizeZ��$2
 ,(Validation.Errors).CurrentItem.ErrorContent�5i      5j      5k      �� 5l      $��2��6   $��2��6"   $��14(�66   $	��120��6D   $��32��6P   $��0 0 0 20q�6\   $��Submit��6n   $	��Top=�6   $��Center=�6�   ��6�   �� *SubmitNewOrderCommand+5m      5n      5o      