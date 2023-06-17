package test;

import java.nio.file.Path;
import java.nio.file.Paths;

public class PathTest {
	public static void main(String[] args) {
		Path p = Paths.get("/home/koz01/aaa");
		System.out.println(p.getParent().get);
	}
}
