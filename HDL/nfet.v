
module nfet (g, a, b);

	input g; 		// Gate
	inout a; 		// Source/Drain
	inout b; 		// Drain/Source

	reg gmem; 		// Gate memory

	initial begin
		gmem <= 1'b0;
	end

	always @(g) begin
		if ( g == 1'b0 || g == 1'b1 )
			gmem <= g;
		else
			gmem <= gmem;
	end

	tranif1 pass (a, b, gmem);

endmodule // nfet
