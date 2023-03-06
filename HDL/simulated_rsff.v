
module nmos_rsff (s, r, q, nq);

	input s;
	input r;
	inout q;
	inout nq;

	nmos_nor g1 (.x(q), .a(r), .b(nq) );
	nmos_nor g2 (.x(nq), .a(q), .b(s) );

endmodule // nmos_rsff

module cmos_rsff (s, r, q, nq);

	input s;
	input r;
	inout q;
	inout nq;

	cmos_nor g1 (.x(q), .a(r), .b(nq) );
	cmos_nor g2 (.x(nq), .a(q), .b(s) );

endmodule // cmos_rsff
