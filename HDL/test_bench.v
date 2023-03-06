// Check all possible combinations on the transistor inputs, including `z`

`timescale 1ns/1ns

module fet_test ();

	reg CLK;
	always #1 CLK = ~CLK;

	wire GateN;
	wire LeftWireN;
	wire RightWireN;

	wire GateP;
	wire LeftWireP;
	wire RightWireP;

	nfet fet_n (.g(GateN), .a(LeftWireN), .b(RightWireN) );
	pfet fet_p (.g(GateP), .a(LeftWireP), .b(RightWireP) );

	FET_TestVectorGenerator test_vector1 (.clk(CLK), .g(GateN), .a(LeftWireN), .b(RightWireN) );
	FET_TestVectorGenerator test_vector2 (.clk(CLK), .g(GateP), .a(LeftWireP), .b(RightWireP) );

	initial begin

		$display("Check FET model.");

		CLK <= 1'b0;

		$dumpfile("fet.vcd");
		$dumpvars(0, fet_n);
		$dumpvars(1, fet_p);

		repeat (32) @ (posedge CLK);

		$finish;
	end

endmodule // fet_test

module FET_TestVectorGenerator (clk, g, a, b);

	input clk;
	output g;
	inout a;
	inout b;

	reg [3:0] cnt;

	initial begin
		cnt <= 4'b1111;
	end

	always @(negedge clk) begin
		cnt <= cnt + 1;
	end

	assign g = cnt[0] == 1'b1 ? (cnt[1]) : 1'bz;
	assign a = cnt[2] == 1'b1 ? (cnt[3]) : 1'bz;
	assign b = cnt[2] == 1'b0 ? (cnt[3]) : 1'bz;

endmodule // FET_TestVectorGenerator
