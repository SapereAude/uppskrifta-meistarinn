   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	   U QMahApps.Metro, Version=0.13.1.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   (    "WpfApplication1.ViewSelectedRecipe   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   /localclr-namespace:WpfApplication1     5   	   Pcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5           	PageStyle#��[  5   	     � WindowStartupLocation$  CenterScreen=�5   	    � 	Resources 5        WpfApplication1.DoubleUp  DoubleUp+  %WpfApplication1.DefaultImageAndResize  DefaultImageAndResize(   "WpfApplication1.FoodProjectDataSet  foodProjectDataSet  mainRecipeDetailsViewSource �� Source �� Source  recipeViewSource  cuisineInfoViewSource��%  &	       &	      &	 &     &	 9     7  &	 p     7  &	 �     7    5	   
   6     5
   
   6&     5   
   6#   �� 5   
    6C   �� *MainRecipeDetails+8   �� 5   
    68   �� *Recipe+8   �� 5   
    6=   �� *CuisineInfo+8   5      .��5      ]� ��.  � DataContext# [ 6%   .+�5   
   � -   5         �Name$ SideNav��5   F     PrimaryColor#��[ 6   $	��200��6:   $
��Left=�6W    J� Opacity$	 0.8Q�6r   $
��Left=�6�   .+�5      �� .+�5      � $	��100��6   .+�5      (� $��80��6   $��Center=�6*   $
��0,10q�6E   .��5      F� $��49.0443��6   $��59.5176��6/    �� Stretch$ Uniform=�6@   
��� �������p6˅ �j�  �Ӭ��� d�x��� d�x��� �p� �6˅ �j�  �6˅ �j�  ���Fv�AT��P^<1v�L6�*�Dk	�*��p�� �*���� \�z�Ǩ h�bӼSw ��,�17 \B��17 \B�� E @Ck��2���镒@@�    ,�Dmb <��-� <���B<�lN��.�<v\�UӔ���.D'�<��,<��h��<�L[� 1�L[����镒@@�L[���2x�@Ck`3�\B��`3�\B�u$�,T�Ch�b�|t+p{x��*�����*�Ӹ!��%�H2�<1v�Fv�AT6`   5      5      �� 5      -   5         ��Name$ btnHome��5      {�. $��_Heim��6;     MenuButtonStyle#���  6a   �� 5      -   5        $ btnAllRecipes��5      $��_Allar Uppskriftir��60   #���  6i   9� 5      $��Nýskrá��6   .��5      �� 	 �� Orientation$	 Vertical=�6!   .+�5      �� -   5        $ btnNewRecipe��5   !   $��Ný _Uppskrift��67   #���  6j   �� 5      -   5        $ btnNewCuisine��5   !   $��Nýr _Flokkur��68   #���  6k   �� 5       -   5        $ btnNewIngredient��5    !   $��Nýtt _Hráefni��6;   #���  6r   5!      5"      9� 5#      $��Skoða��6   .��5$      �� $	 Vertical=�6!   .+�5%      �� -   5        $ btnBrowseRecipe��5%   !   $��_Uppskriftir��6:   #���  6o   �� 5&      -	   5        $ btnBrowseCuisine��5&   !   $��_Flokkar��6;   #���  6m   �� 5'      -
   5        $ btnBrowseIngredient��5'   !   $��	_Hráefni��6>   #���  6s   5(      5)      5+      5,      � 5-   
   -   5        $ FilterSection��5-   H    	 SecondaryColor#��[	 6   $��40��6<   $��Bottom=�6_   
 � Triggers
 5/      :� 50       :� RoutedEvent$ Window.Loaded��6   .[�51      �� .��52      �� -   5         ��Name$
 lala��52   %   .��54      W�  �� 
TargetName$ FilterSection��6.    �� TargetProperty$ (Grid.Height)�6T    W� From$ 40X�6~   	 W� To$ 90X�6�    g� Duration$ 0:0:1D�6�    g� AutoReverse .   W� EasingFunction 55   "   /  )System.Windows.Media.Animation.CircleEase  56   &   7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode$ EaseOut=�61   58      59      5:      5;      .+�5>      �� $	 Vertical=�6   .+�5?      �� $��
Stillingar��6   $��20(�6-   $��Center=�6;   $��Center=�6V   $��55,0,0,0q�6s   $	��107��6�   � 5@      $��Center=�6   $��339,0,308,0q�64   $	��365��6I    � ColumnDefinitions 5A      �� 5B      $��* �6+   �� 5C      $��* �6+   �� 5D      $��* �6+   .+�5L      �� -   5        $ btnEdit��5L   U   $��Breyta��6   $��0��6.   $��75��6>   $��25��6I   $��Center=�6|   $��Center=�6�   $
��10,0q�6�   �� 5M      -   5        $ 	btnDouble��5M   K   $��	Tvöfalda��6   $��1��60   $��75��6@   $��25��6^   $��Center=�6�   $��Center=�6�   $
��10,0q�6�   �� 5N      -   5        $ btnPrint��5N   I   $��Prenta��6   $��2��6.   $��75��6>   $��25��6[   $��Center=�6   $��Center=�6�   $
��10,0q�6�   5O      5P      5Q      � 5R   
   -   5        $ MainBodyGrid��5R       
 MainBodyGridStyle#��[
 6%   .+�5T      � -   5        $ RecipeBoard��5T        GridRecipeStyle#��[ 6(   $
��Auto��6Q   $��	0,0,-2,-2q�6_   .+�5U      ��   SelectedRecipeBorderStyle#��[ 6   ._�5V      � .+�5W      � -   5        $ 	TitleGrid��5W      $
��Left=�63   $��
266,10,0,0q�6N   $	��Top=�6b   $	��176��6z   $	��426��6�   .+�5X      �� -   5         ��Name$ 
RecipeName��5X   (   # [ 6<   $
��Left=�6�   $��30,29,0,119q�6�   $��Center=�6�   $��28��6�   $
��Auto��6�   $��22(�6�   $��SemiBold"�6�   ��6l   �� *name+6�   #   WpfApplication1.RatingControl  5Z      $	��200��62   $��25��6>   # [ 6J   $��10,62,216,89q�6�   {�.     RatingValue 6z   �� *rating+6�   � 5[      -   5        $ CuisineGrid��5[   #   $
��Left=�68   $
��Auto��6S   $��	10,92,0,0q�6a   $	��Top=�6t   $
��Auto��6�   .+�5\   "   �� -   5         ��Name$ cuisineList��5\   *     CuisineListBoxStyle#��[ 6�   ��6?   �� # [ ��5]   &   �� 5^   *   .R�5_   .   ��  ��Name$ cuisineLabel��64   
���   �  CuisineLabelStyle#��[ 6y   ��6J   �� *	Cuisine+6y   5`   +   ��5b   &   �� 5c   *   .R�5d   .   � 5e   /   5f   +   5h   #   5i      5j      � 5m      -   5        $ DescriptionGrid��5m      $��320,191,189,10q�68   .+�5n      �� $��Aðferð��6(   $��18(�66   $
��Bold"�6D   $
��Left=�6V   $��	10,10,0,0q�6q   $	��Top=�6�   $��41��6�   $��99��6�   � 5o      -   5        $ SubDescriptionGrid��5o   #   $
��Left=�6?   $��	0,51,-4,0q�6Z   $	��Top=�6m   $	��238��6�   $	��314��6�   .+�5p   "   �� ��. $��Visible=�6G   $��0,0,27,0q�6m   .��5q   &   �� -   5        $ DescriptionTextBlock��5q   0   $
��Wrap=�6N   $��Right=�6b   # [ 6~   $	��267��6�   {�.  ��6�   �� *description+6�   5r   #   5s      5t      � 5v      -   5        $ RightSideBarGrid��5v      $
��Left=�69   $	��466��6T   $��	15,10,0,0q�6a   $	��Top=�6t   $	��246��6�   .+�5y      � -   5        $ IngrediantsGrid��5y   #   $��10,202,10,-10q�6<   .+�5z   "   �� -   5         ��Name$ RecipeImage��5z   (   # [ 6=   $
��Auto��6�   $��0,-188,0,301q�6�   ��6m   �� *	image_url+ �� 	Converter# [ 6�   �� 5{   "     IngredientScrollViewer#��[ 6/   .��5|   &   &   System.Windows.Controls.DataGrid  -   5          Name$  mainRecipeDetailsDataGArid��5|   /     IngredientsGridStyle#��[ 6S   $
��Left=�6�   $	��216��6�   ��6�   ��    Columns 5}   *   4  .System.Windows.Controls.DataGridTemplateColumn  5~   .   -   5        ingredientsColumn��,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ 3*
 5~   `      CellTemplate 5   2   �� 5�   6   .R�5�   :   ��   DataGridLabelStyle#��[ 6`   ��6@   �� *Ingredients+6`   5�   7   5�   /     5�   .   -   5        quantityColumn��$ 2*
 5�   ]    5�   2   �� 5�   6   .R�5�   :   �� $��Right=�6�   $��Right=�6�   #��[ 6�   ��6@   �� *
Quantity+# [ 6�   5�   7   5�   /     5�   .   -   5        unitsColumn��$ *
 5�   Z    5�   2   �� 5�   6   .R�5�   :   �� #��[ 6Z   ��6@   �� *Units+6Z   5�   7   5�   /   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      