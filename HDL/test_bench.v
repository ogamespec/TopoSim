// Check all possible combinations on the transistor inputs, including `z`

`timescale 1ns/1ns

module fet_test ();

	reg CLK;
	always #1 CLK = ~CLK;

	wire [3:0] cnt_out;

	wire GateN;
	wire LeftWireN;
	wire RightWireN;

	wire GateP;
	wire LeftWireP;
	wire RightWireP;

	nfet fet_n (.g(GateN), .a(LeftWireN), .b(RightWireN) );
	pfet fet_p (.g(GateP), .a(LeftWireP), .b(RightWireP) );

	FET_TestVectorGenerator test_vector1 (.clk(CLK), .g(GateN), .a(LeftWireN), .b(RightWireN), .cnt_out(cnt_out) );
	FET_TestVectorGenerator test_vector2 (.clk(CLK), .g(GateP), .a(LeftWireP), .b(RightWireP) );

	wire out1;
	wire out2;

	nmos_nor my_nmos_nor (.x(out1), .a(cnt_out[0]), .b(cnt_out[1]) );
	cmos_nor my_cmos_nor (.x(out2), .a(cnt_out[0]), .b(cnt_out[1]) );

	initial begin

		$display("Check FET model.");

		CLK <= 1'b0;

		$dumpfile("fet.vcd");
		$dumpvars(0, fet_test);

		repeat (32) @ (posedge CLK);

		$finish;
	end

endmodule // fet_test

module FET_TestVectorGenerator (clk, g, a, b, cnt_out);

	input clk;
	output g;
	inout a;
	inout b;
	output [3:0] cnt_out;

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

	assign cnt_out = cnt;

endmodule // FET_TestVectorGenerator
