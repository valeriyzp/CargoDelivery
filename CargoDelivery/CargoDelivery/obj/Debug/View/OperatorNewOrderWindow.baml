   M S B A M L   `   `   `  ����H  DCargoDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CargoDelivery.ViewCargoDelivery.View  5   	   /    )CargoDelivery.View.OperatorNewOrderWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:CargoDelivery.View     5   	     � Title$  New order | CargoDelivery��5   	   $	��780��6+   $	��500��68    � Icon$: 4/CargoDelivery;component/Resources/CargoDelivery.ico��6D    � 	Resources 5	         GreyTextOverTextBlock �� Property �� Value  GreyTextBox �� 
TargetType  GreyComboBox  
ErrorLabel��%�  &	        &	 �     &	 H    &	 �    �� 5
   
   .�5      ��  � ��$ 14(�61   �� 5       � �� �	#9900000063   �� 5       � ��$ 0 0 0 5q�6/   �� 5       � ��$
 Left=�6<   5      �� 5   
   " ��6$   .�5      ��  � ��$ 14(�61   �� 5       � ��$ 24��6/   �� 5       � ��$ 2q�68   5      �� 5   
   .�5      ��  � ��$ 14(�61   �� 5       � ��$ 24��6/   �� 5       � ��$ 2q�68   5      �� 5   
   .�5      ��  � ��$ 12(�61   �� 5       � ��$ 26��6/   �� 5       � ��
 �  ��63   �� 5       � ��$ 
5, 5, 0, 0q�60   �� 5       � ��$ 
0, 0, 0, 5q�6/   5       5!      .��5"      � 
������� � ColumnDefinitions 5#   
   �� 5$      �� 5%       � RowDefinitions 5'   
   �� 5(      $
��Auto �6   �� 5)      $
��Auto �6   �� 5*      $��* �6   .+�5,   
   �� $��Sender��6   $��20q�6#   .��5-      �� $��10q�6   .+�5.      �� #��[  6   $��
First name��6K   �� 5/      -   5        $��tbSenderFirstName��5/      #��[ 64   ��6Y   �� *NewOrder.SenderFirstName+ �� UpdateSourceTrigger$ PropertyChanged=�	 �� ValidatesOnDataErrors	 . �� 50      #��[ 6   ��6<   �� 
 �� ElementName$
 tbSenderFirstName�� �� Path$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 51      #��[  6   $��	Last name��6K   �� 52      -   5        $��tbSenderLastName��52      #��[ 63   ��6X   �� *NewOrder.SenderLastName+$ PropertyChanged=�	 . �� 53      #��[ 6   ��6<   �� $
 tbSenderLastName��$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 54      #��[  6   $��Phone number��6K   �� 55      -   5        $��tbSenderPhoneNumber��55      #��[ 66   ��6[   �� *NewOrder.SenderPhoneNumber+$ PropertyChanged=�	 . �� 56      #��[ 6   ��6<   �� $
 tbSenderPhoneNumber��$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 57      #��[  6   $
��City��6K   �� 58      -   5        $��tbSenderCity��58      #��[ 6/   ��6T   �� *NewOrder.SenderCity+$ PropertyChanged=�	 . �� 59      #��[ 6   $��0q�6<   ��6G   �� $
 tbSenderCity��$2 ,(Validation.Errors).CurrentItem.ErrorContent�5:      5;      �� 5<   
   $��1��6   $��Receiver��6$   $��20q�66   .��5=      �� $��10q�6   .+�5>      �� #��[  6   $��
First name��6K   �� 5?      -   5        $��tbReceiverFirstName��5?      #��[ 66   ��6[   �� *NewOrder.ReceiverFirstName+$ PropertyChanged=�	 . �� 5@      #��[ 6   ��6<   �� $
 tbReceiverFirstName��$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 5A      #��[  6   $��	Last name��6K   �� 5B      -   5        $��tbReceiverLastName��5B      #��[ 65   ��6Z   �� *NewOrder.ReceiverLastName+$ PropertyChanged=�	 . �� 5C      #��[ 6   ��6<   �� $
 tbReceiverLastName��$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 5D      #��[  6   $��Phone number��6K   �� 5E      -   5        $��tbReceiverPhoneNumber��5E      #��[ 68   ��6]   �� *NewOrder.ReceiverPhoneNumber+$ PropertyChanged=�	 . �� 5F      #��[ 6   ��6<   �� $
 tbReceiverPhoneNumber��$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 5G      #��[  6   $
��City��6K   �� 5H      -   5        $��tbReceiverCity��5H      #��[ 61   ��6V   �� *NewOrder.ReceiverCity+$ PropertyChanged=�	 . �� 5I      #��[ 6   $��0q�6<   ��6G   �� $
 tbReceiverCity��$2 ,(Validation.Errors).CurrentItem.ErrorContent�5J      5K      �� 5L   
   $��1��6   $��2��6    $��Cargo information��65   $��
20 0 20 20q�6P   .��5M      � 
������� 5N      �� 5O      �� 5P      .+�5R      �� $��10 10 35 10q�6   .+�5S      �� #��[  6    $
��Type��6O   �� 5T      -	   5        $��tbType��5T   �   #��[ 6m   ��6   �� *NewOrder.Types+ �� SelectedItem 6F   �� *NewOrder.Type+6�   �� 5U      #��[ 6   ��6@   �� $
 tbType��$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 5V      #��[  6    $��
Weight, kg��6O   �� 5W      -
   5        $��tbWeight��5W      #��[ 6/   ��6T   �� *NewOrder.Weight+$ PropertyChanged=�	 . �� 5X      #��[ 6   ��6@   �� $
 tbWeight��$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 5Y      #��[  6    $��Declared price, UAH��6O   �� 5Z      -   5        $��tbDeclaredPrice��5Z      #��[ 66   ��6[   �� *NewOrder.DeclaredPrice+$ PropertyChanged=�	 . �� 5[      #��[ 6   $��0q�6@   ��6K   �� $
 tbDeclaredPrice��$2 ,(Validation.Errors).CurrentItem.ErrorContent�5\      �� 5]      $��1��6   $��35 10 10 10q�6-   .+�5^      �� #��[  6    $��
Length, sm��6O   �� 5_      -   5        $��tbSizeX��5_      #��[ 6.   ��6S   �� *NewOrder.Size_X+$ PropertyChanged=�	 . �� 5`      #��[ 6   ��6@   �� $
 tbSizeX��$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 5a      #��[  6    $��
Height, sm��6O   �� 5b      -   5        $��tbSizeY��5b      #��[ 6.   ��6S   �� *NewOrder.Size_Y+$ PropertyChanged=�	 . �� 5c      #��[ 6   ��6@   �� $
 tbSizeY��$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 5d      #��[  6    $��	Width, sm��6O   �� 5e      -   5        $��tbSizeZ��5e      #��[ 6.   ��6S   �� *NewOrder.Size_Z+$ PropertyChanged=�	 . �� 5f      #��[ 6   $��0q�6@   ��6K   �� $
 tbSizeZ��$2 ,(Validation.Errors).CurrentItem.ErrorContent�5g      5h      5i      �� 5j   
   $��2��6   $��2��6   $��14(�62   $	��120��6@   $��32��6L   $��0 0 0 20q�6X   $��Submit��6j   $	��Top=�6{   $��Center=�6�   ��6�   �� *SubmitNewOrderCommand+5k      5l      