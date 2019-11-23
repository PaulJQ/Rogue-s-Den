EXTERNAL check_money(x)
VAR flag = "false"
VAR item_purchase = ""
VAR item_sell = ""
Hello my name is Jeff
+[buy potion]
-> buy
+[leave]
-> deez
+[sell your soul]
->sell
==deez==
"nuts, goteem"
~flag = "true"
->END
==buy==
{
-check_money("10") == 1:
->purchase
-else:
->refuse
}
==purchase==
~item_purchase = "potion"
Here you are
->END
==sell==
~item_sell = "your body"
Good doing business with ya
->END
==refuse==
You're too poor
->END