   M S B A M L   `   `   `  ����G  CSuccessPrac3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SuccessPrac3SuccessPrac3  5   	       SuccessPrac3.Admin   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SuccessPrac3     5   	     � Title$  Admin��5   	   $	��528��6   $
��1038��6$   .��5	      � .+�5
   
   �� $/��)пароль адміністратора��6   $
��Left=�60   $��	10,10,0,0q�6K   $	��Top=�6^   �� 5   
   -   5         ��Name$ LogInButton��5      $��LogIn��6&   $
��Left=�66   $��
154,25,0,0q�6Q   $	��Top=�6e   6}   �� 5   
   -   5         ��Name$ UserView��5      $��UserView��6"   $
��Left=�65   $��	19,73,0,0q�6P   $	��Top=�6c   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $��0,104,731,0q�6%      
IsReadOnly$
 True��6:   �� 5   
   $��Change Admin Password��6   $
��Left=�60   $��
598,23,0,0q�6K   $	��Top=�6_   $��20(�6w   �� 5   
   $��OldPassword��6   $
��Left=�6&   $��
424,73,0,0q�6A   $	��Top=�6U   �� 5   
   $��NewPassword��6   $
��Left=�6&   $��
583,73,0,0q�6A   $	��Top=�6U   �� 5   
   $��NewPassword��6   $
��Left=�6&   $��
763,73,0,0q�6A   $	��Top=�6U   �� 5   
   -   5        $ UpdatePasswd��5      $��Update��6'   $
��Left=�68   $��
929,93,0,0q�6S   $	��Top=�6g   6   �� 5   
   $��UserData��6   $
��Left=�6#   $��354,154,0,0q�6>   $	��Top=�6S   $
��Bold"�6k   $��Italic$�6}   �� 5   
   -   5        $ UserNameSelected��5      $
��Name��6*   $
��Left=�69   $��435,194,0,0q�6T   $	��Top=�6i    J� RenderTransformOrigin$ 0.553,0.668&�6�   �� 5   
   -   5        $ UserSurnameSelected��5      $��SurName��6-   $
��Left=�6?   $��434,238,0,0q�6Z   $	��Top=�6o   �� 5   
   -   5        $ UserLoginSelected��5      $��Login��6+   $
��Left=�6;   $��678,194,0,0q�6V   $	��Top=�6k   �� 5   
   -   5        $ UserStatusSelected��5      $��Status��6,   $
��Left=�6=   $��679,238,0,0q�6X   $	��Top=�6m   �� 5   
   -	   5        $
 Prev��5      $��Previous��6   $
��Left=�62   $��359,308,0,0q�6M   $	��Top=�6b   6z   �� 5   
   -
   5        $
 Next��5      $
��Next��6   $
��Left=�6.   $��790,308,0,0q�6I   $	��Top=�6^   $ 0.663,1.614&�6v   6�   �� 5   
   -   5        $ UserRestrictionSelected��5      $��PasswordLimitation��61   $
��Left=�6N   $��625,305,0,0q�6i   $	��Top=�6~   �� 5   
   $��AddUser��6   $
��Left=�6"   $��357,351,0,0q�6=   $	��Top=�6R   $��15(�6j   $
��Bold"�6x   $��Italic$�6�   �� 5   
   -   5        $ AddUser��5      $��AddUser��6"   $
��Left=�64   $��324,462,0,0q�6O   $	��Top=�6d   6|   �� 5   
   $
��User��6   $
��Left=�6   $��324,396,0,0q�6:   $	��Top=�6O   $ 0.562,0.597&�6g   �� 5   
   $
��Left=�6   $��374,398,0,0q�6.   $	��Top=�6C   $	��120��6[   �� 5   
   $��Activity��6   $
��Left=�6&   $��594,378,0,0q�6A   $	��Top=�6V   �� 5    
   $��PasswordLimitations��6   $
��Left=�61   $��594,404,0,0q�6L   $	��Top=�6a   �� 5!   
   $��SetActivity��6   $
��Left=�6'   $��745,371,0,0q�6B   $	��Top=�6W   �� 5"   
   $��SetLimiations��6   $
��Left=�6)   $��755,402,0,0q�6D   $	��Top=�6Y   �� 5#   
   $��UserName��6   $
��Left=�6#   $��341,194,0,0q�6>   $	��Top=�6S   �� 5$   
   $��UserSurName��6   $
��Left=�6&   $��340,238,0,0q�6A   $	��Top=�6V   �� 5%   
   $��Login��6   $
��Left=�6    $��604,194,0,0q�6;   $	��Top=�6P   �� 5&   
   $��
UserStatus��6   $
��Left=�6%   $��604,238,0,0q�6@   $	��Top=�6U   �� 5'   
   $��PasswordLimitations��6   $��Center=�6.   $��	0,305,0,0q�6K   $	��Top=�6^   G� 5(   
   -   5         G�Name$ RealAdminPasswd��5(      $
��Left=�6/   $��404,104,0,0q�6J   $	��Top=�6_   $	��120��6w   G� 5)   
   -   5        $ NewAdminPasswd��5)      $
��Left=�6.   $��565,104,0,0q�6I   $	��Top=�6^   $	��120��6v   G� 5*   
   -   5        $ NewAdminPasswd2��5*      $
��Left=�6/   $��744,103,0,0q�6J   $	��Top=�6_   $	��120��6w   G� 5+   
   -   5        $ AdminPasswd��5+      $
��Left=�6+   $��	19,41,0,0q�6F   $	��Top=�6Y   $	��120��6q   �� 5,   
   -   5         ��Name$ AddingUserLogin��5,      $
��Left=�6+   $��435,357,0,0q�6F   $�� ��6[    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��120��6�   5.      5/      