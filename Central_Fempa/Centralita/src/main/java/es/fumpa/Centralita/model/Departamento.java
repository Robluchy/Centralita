package es.fumpa.Centralita.model;

import jakarta.persistence.*;

import java.util.List;

@Entity
public class Departamento {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    private Long id;
    private String nombre;
    @OneToMany(mappedBy = "departamento")
    List<Usuario> usuarios;
    public Long getId() {
        return id;
    }

    public Departamento(String nombre) {
        this.nombre = nombre;
    }

    public Departamento() {
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public void setId(Long id) {
        this.id = id;
    }

    @Override
    public String toString() {
        return "Departamento{" +
                "id=" + id +
                ", nombre='" + nombre + '\'' +
                '}';
    }
}
