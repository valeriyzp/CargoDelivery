   M S B A M L   `   `   `  ����H  DCargoDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CargoDelivery.ViewCargoDelivery.View  5   	   $    CargoDelivery.View.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:CargoDelivery.View     5   	     � Title$  CargoDelivery��5   	   $	��480��6   $	��300��6,    � 
ResizeMode$ NoResize=�68    � Icon$" /Resources/CargoDelivery.ico��6N    � 	Resources 5	         GreyTextOverTextBlock �� Property �� Value  GreyTextBox �� 
TargetType  
ErrorLabel��%  &	        &	 �     &	 H    �� 5
   
   .�5      ��  � ��$ 14(�61   �� 5       � �� �	#9900000063   �� 5       � ��$ 0 0 0 5q�6/   �� 5       � ��$
 Left=�6<   5      �� 5   
   " ��6$   .�5      ��  � ��$ 14(�61   �� 5       � ��$ 24��6/   �� 5       � ��$ 2q�68   5      �� 5   
   .�5      ��  � ��$ 12(�61   �� 5       � ��$ 26��6/   �� 5       � ��
 �  ��63   �� 5       � ��$ 
5, 5, 0, 0q�60   5      5      .��5      �� .+�5   
   �� $��0 15 0 0q�6   .+�5      �� $��/Resources/LoginImage.png��6   $��96��67   $��96��6B   �� 5      $��36(�6   $��Center=�6&   $��Login��6C   5       �� 5!   
   $	��200��6   $��0, 15, 0, 30q�6!   .+�5"      �� #��[  6   $��Username��6G   �� 5#      -   5        $��
tbUsername��5#      #��[ 6)   ��6N   �� *user.Username+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . �� 5$      #��[ 6   $��0, 0, 0, 15q�68   ��6M   �� 	 �� ElementName$	 
tbUsername��
 �� Path$2
 ,(Validation.Errors).CurrentItem.ErrorContent��� 5%      #��[  6   $��Password��6G   �� 5&      -   5        $��
tbPassword��5&      #��[ 6(   ��6M   �� *user.Password+$ PropertyChanged=� . �� 5'      #��[ 6   ��68   �� $	 
tbPassword��$2
 ,(Validation.Errors).CurrentItem.ErrorContent��� 5(      
������ $��0q�6.   $��Right=�6C   ���#0078D7$��Create account��6t   $��0,0,5,0q�6�   ��6�   �� *CreateAccountCommand+�� 5)      $��14(�6   $	��120��6#   $��32��6/   $��0 30 0 0q�6;   $��Sign In��6M   ��6_   �� *SignInCommand+5*      5+      5,      