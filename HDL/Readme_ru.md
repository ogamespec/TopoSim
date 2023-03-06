# HDL

Тестирование HDL модели транзистора (nfet/pfet).

![fet_model](/imgstore/fet_model.png)

В основу модели положены примитивы Verilog tranif0/tranif1, а также обычный регистр (reg), для имитации памяти на затворе (DLatch).

## nor

![CMOS-implementation-of-NOR-gate-G-2.png](/imgstore/CMOS-implementation-of-NOR-gate-G-2.png)

```verilog
module sim_nor (x, a, b);

	output x;
	input a;
	input b;

	wire gnd = 1'b0;
	wire vdd = 1'b1;
	wire g3out;

	nfet g1 (.g(a), .a(gnd), .b(x) );
	nfet g2 (.g(b), .a(gnd), .b(x) );
	pfet g3 (.g(a), .a(vdd), .b(g3out) );
	pfet g4 (.g(b), .a(g3out), .b(x) );

endmodule // sim_nor
```

![nor_model](/imgstore/nor_model.png)
