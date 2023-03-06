# TopoSim

Transistor circuit simulator based on chip topology pictures.

![TopoSimLatest](/imgstore/TopoSimLatest.png)

<concept picture>

The development of the simulator will be done in a kind of "waves" or layers (Layer). After each layer is implemented, some useful features will be implemented, which themselves can already be applied somehow.

All of the layers above depend on the layers below, which is why it is so organized.

## Layer0

Application Skeleton.

## Layer1

A set of layers (.png format images, for example) representing the actual chip topology as well as JSON of a certain format, with additional information about the topology:
- Layer types (metal, diffusion, etc.)
- The lambda parameter sets the error as well as the minimum feature size (essentially a metric)
- Colors (to filter out only actual pixels of the layer)
- Other

## Layer2

Topology pictures are transformed into segments. A segment is a rectangular section of the topology, in lambda metrics. The task of segmenting is to transform a bitmap with layers of complex shape into docking segments. Segments are easier and faster to work with than pixels.

You can save segmented pictures for debugging purposes. Segmented pictures may differ from the original topology because areas that are smaller than the metric will be discarded.

Additionally, various auxiliary things can be done on this layer, such as auto-alignment of vias, straightening of wires, etc.

## Layer3

The segments are transformed into a netlist (wires and transistors). A correspondence is set between wires and segments, so that for example one wire, which is represented by several mask segments, can be selected.

As debugging, the netlist is saved in a reduced Verilog, which contains only wires and transistors (nfet/pfet modules).

## Development Stages

- Layer1: Learn to load images and parse JSON (trivial)
- Layer2: Convert picture of each layer in a list of segments (`List<Segment>`); Make a control to display segments; Option to highlight or somehow select the segment with special colors: 0, 1, z, x (for simulation)
- Layer3: Create netlist from segments; Netlist simulation (graph traversal); Module for finding wires (Edges); Module for finding transistors (Nodes)
- Layer4 (not yet): Find more complex modules (nor/nand) in the netlist and simulate them in their entirety, to speed up

## How the simulation happens

- The whole graph (netlist) is traversed
- When entering a Node, the nfet/pfet model works
- The traversal takes place until the old Node/Edge values are equal to the new Node/Edge values ("stabilization" of the circuit)
- Each Node/Edge has a propagation counter. It can be used to display the propagation heat map of signals
